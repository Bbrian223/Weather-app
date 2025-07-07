using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {

        private readonly WeatherServices _climaService = new WeatherServices();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string ciudad)
        {
            var result = await _climaService.GetWeatherAsync(ciudad);

            if (result != null)
                return View(result);


            ViewBag.ErrorMessage = "No se obtubieron datos de la ciudad especificada";
            return View();
        }
    }
}