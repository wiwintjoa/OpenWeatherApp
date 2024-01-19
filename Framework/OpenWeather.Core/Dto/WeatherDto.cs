using Newtonsoft.Json;
using OpenWeather.Core.Dto.Map;
using System;

namespace OpenWeather.Core.Dto
{
    public class WeatherDto
    {
        [JsonProperty("name")]
        public string Title { get; set; }

        [JsonProperty("coord")]
        public Coord Coord { get; set; }

        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("cod")]
        public long Cod { get; set; }

        public string CurrentDateTime { get; set; }

        public double TemperatureC { get; set; }

        public double TemperatureF { get; set; }

        public double TemperatureMinC { get; set; }

        public double TemperatureMaxC { get; set; }
    }
}
