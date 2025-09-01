using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class PlayerStatDto
    {
        public int Id { get; set; }

        [JsonPropertyName("uid")]
        public long Uid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("updates")]
        public PlayerUpdatesDto Updates{ get; set; }

        [JsonPropertyName("player")]
        public PlayerDto Player { get; set; }

        [JsonPropertyName("overall_stats")]
        public PlayerOverallStatsDto OverallStats { get; set; }
    }
}