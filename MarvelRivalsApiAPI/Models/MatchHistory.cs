using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MarvelRivalsApiAPI.Models
{
    public class MatchHistory
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("match_map_id")]
        public int MatchMapId { get; set; }

        [JsonPropertyName("match_map_name")]
        public string? MatchMapName { get; set; }

        [JsonPropertyName("map_thumbnail")]
        public string? MapThumbnail { get; set; }

        [JsonPropertyName("match_play_duration")]
        public double MatchPlayDuration { get; set; }

        [JsonPropertyName("match_season")]
        public string? MatchSeason { get; set; }

        [JsonPropertyName("match_uid")]
        public string? MatchUid { get; set; }

        [JsonPropertyName("match_winner_side")]
        public int MatchWinnerSide { get; set; }

        [JsonPropertyName("mvp_uid")]
        public int MvpUid { get; set; }

        [JsonPropertyName("svp_uid")]
        public int SvpUid { get; set; }

        [JsonPropertyName("score_info")]
        public ScoreInfo? ScoreInfo { get; set; }

        [JsonPropertyName("match_time_stamp")]
        public long MatchTimeStamp { get; set; }

        [JsonPropertyName("play_mode_id")]
        public int PlayModeId { get; set; }

        [JsonPropertyName("game_mode_id")]
        public int GameModeId { get; set; }

        [JsonPropertyName("match_player")]
        public MatchPlayer MatchPlayer { get; set; }
    }
}       