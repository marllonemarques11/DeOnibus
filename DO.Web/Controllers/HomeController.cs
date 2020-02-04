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

namespace DO.Web.Controllers
{
    public class HomeController : Controller
    {
        private ITravelBusiness _travelBusiness;
        HttpClient client = new HttpClient();

        public HomeController(ITravelBusiness travelBusiness)
        {
            _travelBusiness = travelBusiness;
            client.BaseAddress = new Uri("https://4jehkg0izj.execute-api.us-east-1.amazonaws.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IActionResult> Index()
        {
            DeOnibusModel model = new DeOnibusModel();
            HttpResponseMessage response = await client.GetAsync("stage-v0/route");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<DeOnibusModel>(data);
            }
            return View(model);
        }

        //requisições

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
