using Newtonsoft.Json;

namespace OpenWeatherMvc.Models
{
    public class WeatherApiData
    {
        [JsonProperty("data")]
        public WeatherModel Data { get; set; }
    }
}
