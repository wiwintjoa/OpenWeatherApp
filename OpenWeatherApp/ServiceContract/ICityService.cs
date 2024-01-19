using OpenWeather.Core.Dto;
using OpenWeatherApp.ServiceContract.Response;

namespace OpenWeatherApp.ServiceContract
{
    public interface ICityService
    {
        GenericGetDtoCollectionResponse<CityDto> GetAll(string country);
    }
}
