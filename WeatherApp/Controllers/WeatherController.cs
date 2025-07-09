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

        private readonly WeatherServices _weatherService = new WeatherServices();

        [HttpGet]
        public ActionResult Index()
        { 
            return View();
        }


        public async Task<ActionResult> GetCurrentWeather(double lat, double lon)
        {   
            var result = await _weatherService.GetWeatherForCoordAsync(lat,lon);

            if(result != null)
                return View("Index",result);

            ViewBag.ErrorMessage = "Errror al obtener datos actuales";
            return View("Index");
        }

    }
}