using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarvelRivalsApi.Models.Entities
{
    /// <summary>
    /// /// <summary>
    /// Represents a record of a match in a match-history.
    /// </summary>
    public class MatchHistory
    {
        [Key]
        public int Id { get; set; }
        public string MatchUid { get; set; } = string.Empty;
        public int MatchMapId { get; set; }
        public string MatchMapName { get; set; } = string.Empty;
        public string MapThumbnail { get; set; } = string.Empty;
        public double MatchPlayDuration { get; set; }
        public string MatchSeason { get; set; } = string.Empty;
        public int MatchWinnerSide { get; set; }
        public int MvpUid { get; set; }
        public int SvpUid { get; set; }
        public long MatchTimeStamp { get; set; }
        public int PlayModeId { get; set; }
        public int GameModeId { get; set; }
        //Navigation Properties
        public int MatchPlayerId { get; set; }
        [ForeignKey("MatchPlayerId")]
        public MatchPlayer? MatchPlayer { get; set; }

        [ForeignKey("ScoreInfoId")]
        public ScoreInfo? ScoreInfo { get; set; }
    }
}