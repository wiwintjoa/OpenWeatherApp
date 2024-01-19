using OpenWeather.Core.Dto;
using OpenWeatherApp.ServiceContract.Response;

namespace OpenWeatherApp.ServiceContract
{
    public interface ICountryService
    {
        GenericGetDtoCollectionResponse<CountryDto> GetAll();
    }
}
