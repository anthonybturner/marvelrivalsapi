using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class PlayerScoreInfoDto
    {
        [JsonPropertyName("add_score")]
        public double? AddScore { get; set; }

        [JsonPropertyName("level")]
        public int? Level { get; set; }

        [JsonPropertyName("new_level")]
        public int? NewLevel { get; set; }

        [JsonPropertyName("new_score")]
        public double? NewScore { get; set; }
    }
}
