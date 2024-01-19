using Microsoft.Extensions.DependencyInjection;
using OpenWeather.Service;
using OpenWeatherApp.Service;
using OpenWeatherApp.ServiceContract;

namespace OpenWeatherApp
{
    public class Bootstrapper
    {
        public static void SetupServices(IServiceCollection service)
        {
            service.AddScoped<ICityService, CityService>();
            service.AddScoped<ICountryService, CountryService>();
            service.AddScoped<IOpenWeatherMapService, OpenWeatherMapService>(); 
        }
    }
}
