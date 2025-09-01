using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class PlayerOverallStatsDto
    {

        [JsonPropertyName("total_matches")]
        public int TotalMatches { get; set; }

        [JsonPropertyName("total_wins")]
        public int TotalWins { get; set; }

        [JsonPropertyName("unranked")]
        public PlayerUnrankedDto Unranked { get; set; }

        [JsonPropertyName("ranked")]
        public PlayerRankedDto Ranked { get; set; }

    }
}