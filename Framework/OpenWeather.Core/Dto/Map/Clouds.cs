using Newtonsoft.Json;

namespace OpenWeather.Core.Dto.Map
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}
