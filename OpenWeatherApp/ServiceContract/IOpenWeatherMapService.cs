using OpenWeather.Core.Dto;
using OpenWeatherApp.ServiceContract.Response;
using System.Threading.Tasks;

namespace OpenWeatherApp.ServiceContract
{
    public interface IOpenWeatherMapService
    {
        Task<GenericResponse<WeatherDto>> GetWeatherData(string city);
    }
}
