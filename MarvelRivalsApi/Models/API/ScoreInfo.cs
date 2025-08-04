using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class ScoreInfo
    {
        [JsonPropertyName("0")]
        public int Zero { get; set; }

        [JsonPropertyName("1")]
        public int One { get; set; }
    }
}
