using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DO.Web.Models;
using DO.Business.Contracts;
using DO.Web.Utils;

namespace DO.Web.Controllers
{
    public class HomeController : Controller
    {
        private ITravelBusiness _travelBusiness;

        public HomeController(ITravelBusiness travelBusiness)
        {
            _travelBusiness = travelBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        //requisições

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
