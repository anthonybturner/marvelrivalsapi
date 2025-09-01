using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class PlayerUnrankedDto
    {

        [JsonPropertyName("total_matches")]
        public int TotalMatches { get; set; }

        [JsonPropertyName("total_wins")]
        public int TotalWins { get; set; }

        [JsonPropertyName("total_assists")]
        public int TotalAssists{ get; set; }

        [JsonPropertyName("total_deaths")]
        public int TotalDeaths { get; set; }

        [JsonPropertyName("total_kills")]
        public int TotalKills { get; set; }

        [JsonPropertyName("total_time_played")]
        public string TotalTimePlayed { get; set; }

        [JsonPropertyName("total_time_played_raw")]
        public float TotalTimePlayedRaw { get; set; }

        [JsonPropertyName("total_mvp")]
        public int TotalMvp { get; set; }
        
        [JsonPropertyName("total_svp")]
        public int TotalSvp { get; set; }
    }
}