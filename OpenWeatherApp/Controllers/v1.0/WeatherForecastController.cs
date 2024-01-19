using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OpenWeatherApp.ServiceContract;
using penWeatherApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace OpenWeatherApp.Controllers
{
    [Route("v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class WeatherForecastController : BaseController
    {
        #region Fields

        private readonly ICountryService countryService;
        private readonly ICityService cityService;
        private readonly IOpenWeatherMapService openWeatherMapService;

        #endregion

        #region Constructor

        public WeatherForecastController(
            ICountryService countryService,
            ICityService cityService,
            IOpenWeatherMapService openWeatherMapService
            )
        {
            this.countryService = countryService;
            this.cityService = cityService;
            this.openWeatherMapService = openWeatherMapService;
        }

        #endregion

        /// <summary>
        /// Get List Of Country.
        /// </summary>
        /// <response code="200">Success Response.</response>
        /// <response code="404">Country is not found.</response>
        /// <response code="500">Exception thrown.</response>
        [HttpGet]
        [Route("/v{version:apiversion}/Countries")]
        public IActionResult GetCountry()
        {
            var countryResponse = countryService.GetAll();

            if (countryResponse.IsError())
            {
                return this.GetApiError(countryResponse.GetMessageErrorTextArray(), (int)HttpStatusCode.NotFound);
            }

            var response = new List<Object>(countryResponse.DtoCollection.Count);

            foreach(var country in countryResponse.DtoCollection)
            {
                response.Add(country);
            }

            return new OkObjectResult(response);
        }

        /// <summary>
        /// Get List Of City based on country code.
        /// </summary>
        /// <parameter>Country</parameter>
        /// <response code="200">Success Response.</response>
        /// <response code="404">Country is not found.</response>
        /// <response code="500">Exception thrown.</response>
        [HttpGet]
        [Route("/v{version:apiversion}/Cities")]
        public IActionResult GetCity([FromQuery][Required] string countryCode)
        {
            var cityResponse = cityService.GetAll(countryCode);

            if (cityResponse.IsError())
            {
                return this.GetApiError(cityResponse.GetMessageErrorTextArray(), (int)HttpStatusCode.NotFound);
            }

            var response = new List<Object>(cityResponse.DtoCollection.Count);

            foreach (var city in cityResponse.DtoCollection)
            {
                response.Add(city);
            }

            return new OkObjectResult(response);
        }

        /// <summary>
        /// Get Weather Map.
        /// </summary>
        /// <parameter>City</parameter>
        /// <response code="200">Success Response.</response>
        /// <response code="404">Country is not found.</response>
        /// <response code="500">Exception thrown.</response>
        [HttpGet]
        [Route("/v{version:apiversion}/OpenWeather")]
        public async Task<IActionResult> GetOpenWeather([FromQuery][Required] string city)
        {
            var openWeatherResponse = await openWeatherMapService.GetWeatherData(city);

            if (openWeatherResponse.IsError())
            {
                return this.GetApiError(openWeatherResponse.GetMessageErrorTextArray(), (int)HttpStatusCode.NotFound);
            }

            return new OkObjectResult(openWeatherResponse);
        }
    }
}
