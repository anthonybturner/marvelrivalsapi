using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class MatchPlayerDto
    {
        [JsonPropertyName("kills")]
        public int Kills { get; set; }

        [JsonPropertyName("deaths")]
        public int Deaths { get; set; }

        [JsonPropertyName("assists")]
        public int Assists { get; set; }

        [JsonPropertyName("is_win")]
        public WinInfoDto IsWin { get; set; } = new();

        [JsonPropertyName("disconnected")]
        public bool Disconnected { get; set; }

        [JsonPropertyName("player_uid")]
        public long? PlayerUid { get; set; }

        public string PlayerName { get; set; } = string.Empty;

        [JsonPropertyName("camp")]
        public int? Camp { get; set; }

        [JsonPropertyName("score_info")]
        public PlayerScoreInfoDto? ScoreInfo { get; set; }

        [JsonPropertyName("player_hero")]
        public PlayerHeroDto PlayerHero { get; set; } = new();
    }
}
