using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DO.Web.Models;
using DO.Business.Contracts;
using DO.Web.Utils;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using DO.Domain.Entities;
using System.Globalization;

namespace DO.Web.Controllers
{
    public class HomeController : Controller
    {
        private ITravelBusiness _travelBusiness;
        HttpClient client = new HttpClient();
        Converter converter = new Converter();
        Formater formater = new Formater();

        public HomeController(ITravelBusiness travelBusiness)
        {
            _travelBusiness = travelBusiness;
            
            client.BaseAddress = new Uri("https://4jehkg0izj.execute-api.us-east-1.amazonaws.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IActionResult> Index()
        {
            DeOnibusModel model = new DeOnibusModel();
            model.TravelsAvailable = await GetTravelsAPI();

            var favoriteTravels = await _travelBusiness.GetTravels();
            model.FavoriteTravels = favoriteTravels.Any() ? converter.EntitytoModel(favoriteTravels) : new List<TravelModel>();

            MergeTravels(model);

            formater.RemoveNumbersWithoutSense(model.TravelsAvailable);
            formater.RemoveNumbersWithoutSense(model.FavoriteTravels);

            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void MergeTravels(DeOnibusModel model)
        {
            model.TravelsAvailable.RemoveAll(x => model.FavoriteTravels.Any(y => y.objectId == x.objectId));
        }

        public async Task<bool> InsertTravels([FromBody]List<TravelModel> travelsModel)
        {
            List<Travel> travelsEntity = converter.ModeltoEntity(travelsModel);
            return await _travelBusiness.InsertTravels(travelsEntity);
        }

        public async Task<bool> DeleteTravels(string objectsId)
        {
            return await _travelBusiness.DeleteTravels(objectsId);
        }

        public async Task<List<TravelModel>> GetTravelsAPI()
        {
            List<TravelModel> travels = new List<TravelModel>();
            HttpResponseMessage response = await client.GetAsync("stage-v0/route");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                travels = JsonConvert.DeserializeObject<DeOnibusModel>(data).TravelsAvailable.OrderBy(p => p.DepartureDate.iso).ToList();
            }
            return await Task.FromResult(travels);
        }

        //public async Task<IActionResult> Filter(string period, string busClass, string priceLimit)
        //{
        //    DeOnibusModel model = new DeOnibusModel();

        //    string[] rangeHours = period.Split(',');

        //    var travels = await GetTravelsAPI();

        //    if (!string.IsNullOrWhiteSpace(busClass))
        //        travels.Where(obj => obj.BusClass == busClass).ToList();

        //    if (!string.IsNullOrWhiteSpace(priceLimit))
        //        travels.Where(obj => obj.Price <= Convert.ToInt32(priceLimit));

        //    if (!string.IsNullOrWhiteSpace(period))
        //    {
        //        DateTime startHour = Convert.ToDateTime(rangeHours[0]);
        //        DateTime endHour = Convert.ToDateTime(rangeHours[1]);
        //        travels.Where(obj => obj.DepartureDate.iso >= startHour && obj.DepartureDate.iso <= endHour);
        //    }

        //    model.FavoriteTravels = converter.EntitytoModel(await _travelBusiness.GetTravels());

        //    MergeTravels(model);

        //    return View(model);
        //}
    }
}
