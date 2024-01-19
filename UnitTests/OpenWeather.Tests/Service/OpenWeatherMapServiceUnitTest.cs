using Moq;
using OpenWeather.Service;
using OpenWeatherApp.ServiceContract;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace OpenWeather.Tests.Service
{
    public class OpenWeatherMapServiceUnitTest
    {
        #region Fields
        
        private Mock<HttpClient> httpClientMock;
        IOpenWeatherMapService service;

        #endregion

        #region Constructors

        public OpenWeatherMapServiceUnitTest()
        {
            this.httpClientMock = new Mock<HttpClient>();
            this.service = new OpenWeatherMapService();
        }

        #endregion Constructors

        #region Test Method

        [Fact]
        public async Task GetCelciusTemperature_Success()
        {
            //Act
            var actualResult = await service.GetWeatherData("London");
            double temperatureCelcius = 0;
            
            if (actualResult.Data.Main != null)
            {
                temperatureCelcius = Math.Round(actualResult.Data.Main.Temperature - 273.15, 3);
            } else
            {
                temperatureCelcius = 0;
            }

            //Assert
            Assert.Equal(temperatureCelcius, actualResult.Data.TemperatureC);
        }

        [Fact]
        public async Task GetCelciusTemperature_Failed()
        {
            //Act
            var actualResult = await service.GetWeatherData("London");

            var temperatureCelcius = 0;

            //Assert
            Assert.False(temperatureCelcius.Equals(actualResult.Data.TemperatureC));
        }

        [Fact]
        public async Task GetOpenWeatherAPI_Failed()
        {
            //Act
            var actualResult = await service.GetWeatherData("");

            //Assert
            Assert.True(actualResult.IsError());
            Assert.Null(actualResult.Data);
        }

        #endregion
    }
}
