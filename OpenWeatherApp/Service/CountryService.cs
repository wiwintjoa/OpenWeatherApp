using OpenWeather.Core.Dto;
using OpenWeather.Core.Resource;
using OpenWeatherApp.Mock;
using OpenWeatherApp.Service;
using OpenWeatherApp.ServiceContract;
using OpenWeatherApp.ServiceContract.Response;
using System.Linq;

namespace OpenWeather.Service
{
    public class CountryService : BaseService<CountryDto>, ICountryService
    {
        public CountryService() { }

        public GenericGetDtoCollectionResponse<CountryDto> GetAll() 
        {
            var response = new GenericGetDtoCollectionResponse<CountryDto>();

            var countries = Countries.GetCountries();

            if (!countries.Any())
            {
                response.AddErrorMessage(OpenWeatherResource.Country_NotAvailable);
                return response;
            }

            foreach (var country in countries)
            {
                var countryDto = new CountryDto
                {
                    Code = country.Value,
                    Name = country.Text
                };

                response.DtoCollection.Add(countryDto);
            }

            return response;
        }
    }
}
