using Newtonsoft.Json;

namespace OpenWeatherApp.Model
{
    public class ApiErrorModel
    {
        [JsonProperty("errorMessages")]
        public string[] ErrorMessages { get; set; }
    }
}
