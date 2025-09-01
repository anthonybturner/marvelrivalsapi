using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class PlayerRankDto
    {
        [JsonPropertyName("rank")]
        public string Rank { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

    }
}