using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenWeatherMvc.Models;
using OpenWeatherMvc.Service;
using System.Diagnostics;

namespace OpenWeatherMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public RestService _restService { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _restService = new RestService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult WeatherView(string city)
        {
            string apiResult = "https://localhost:44375/v1/OpenWeather?city=london";
            WeatherApiData weatherApiModel = _restService.GetWeatherData(apiResult).Result;

            return View(weatherApiModel);
        }
    }
}
