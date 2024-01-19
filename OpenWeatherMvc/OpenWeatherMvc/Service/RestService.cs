using System.Net.Http;
using System.Threading.Tasks;
using System;
using OpenWeatherMvc.Models;
using Newtonsoft.Json;

namespace OpenWeatherMvc.Service
{
    public class RestService
    {
        HttpClient _client;


        public RestService()
        {
            _client = new HttpClient();

        }

        public async Task<WeatherApiData> GetWeatherData(string query)
        {
            WeatherApiData weatherData = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherApiData>(content);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return weatherData;
        }
    }
}
