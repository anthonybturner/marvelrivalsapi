using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class MatchHistoryDto
    {
        public int Id { get; set; }

        [JsonPropertyName("match_uid")]
        public string MatchUid { get; set; } = string.Empty;

        [JsonPropertyName("match_map_id")]
        public int MatchMapId { get; set; }

        public string MatchMapName { get; set; } = string.Empty;

        [JsonPropertyName("map_thumbnail")]
        public string MapThumbnail { get; set; } = string.Empty;

        [JsonPropertyName("match_play_duration")]
        public double MatchPlayDuration { get; set; }

        [JsonPropertyName("match_season")]
        public string MatchSeason { get; set; } = string.Empty;

        [JsonPropertyName("match_winner_side")]
        public int MatchWinnerSide { get; set; }

        [JsonPropertyName("mvp_uid")]
        public int MvpUid { get; set; }

        [JsonPropertyName("svp_uid")]
        public int SvpUid { get; set; }

        [JsonPropertyName("score_info")]
        public Dictionary<string, int> ScoreInfo { get; set; } = [];

        [JsonPropertyName("match_time_stamp")]
        public long MatchTimeStamp { get; set; }

        [JsonPropertyName("play_mode_id")]
        public int PlayModeId { get; set; }

        [JsonPropertyName("game_mode_id")]
        public int GameModeId { get; set; }

        [JsonPropertyName("match_player")]
        public MatchPlayerDto MatchPlayer { get; set; } = new();
    }

}
