using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OpenWeather.Core.Dto;
using OpenWeatherApp.Controllers;
using OpenWeatherApp.ServiceContract;
using OpenWeatherApp.ServiceContract.Response;
using Xunit;

namespace OpenWeather.Tests.Controller
{
    public class OpenWeatherMapControllerUnitTest
    {
        #region Fields

        private Mock<IOpenWeatherMapService> openWeatherServiceMock;
        private Mock<ICountryService> countryServiceMock;
        private Mock<ICityService> cityServiceMock;

        private WeatherForecastController controller;

        #endregion

        #region Constructors

        public OpenWeatherMapControllerUnitTest()
        {
            this.countryServiceMock = new Mock<ICountryService>();
            this.cityServiceMock = new Mock<ICityService>();
            this.openWeatherServiceMock = new Mock<IOpenWeatherMapService>();

            this.controller = new WeatherForecastController(
                this.countryServiceMock.Object,
                this.cityServiceMock.Object,
                this.openWeatherServiceMock.Object
                );
        }

        #endregion

        #region Test Method

        [Fact]
        public async void GetOpenWeather_ReturnsNotFoundStatus()
        {
            var response = new GenericResponse<WeatherDto>();

            response.AddErrorMessage(It.IsAny<string>());

            this.openWeatherServiceMock
               .Setup(service => service.GetWeatherData(It.IsAny<string>()))
               .ReturnsAsync(response);

            var result = (ObjectResult)await this.controller.GetOpenWeather(null).ConfigureAwait(true);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public async void GetOpenWeather_ReturnsSuccessStatus()
        {
            var response = new GenericResponse<WeatherDto>();

            this.openWeatherServiceMock
               .Setup(service => service.GetWeatherData(It.IsAny<string>()))
               .ReturnsAsync(response);

            var result = (OkObjectResult)await this.controller.GetOpenWeather(It.IsAny<string>()).ConfigureAwait(true);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        #endregion
    }
}
