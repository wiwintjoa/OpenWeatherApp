using Newtonsoft.Json;

namespace OpenWeather.Core.Dto.Map
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public long Deg { get; set; }
    }
}
