using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;

namespace MarvelRivalsApi.Models.Entities
{

    /// <summary>
    /// Represents a player participating in a match, including their performance statistics,
    /// connection status, and related navigation properties for match history, win information,
    /// score details, and hero selection.
    /// </summary>
    public class MatchPlayer
    {
        [Key]
        public int Id { get; set; }
        public long? PlayerUid { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public bool Disconnected { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public int? Camp { get; set; }

        //Navigation Properties
        public required MatchHistory MatchHistory { get; set; }
        public int IsWinId { get; set; }
        [ForeignKey("IsWinId")]
        public WinInfo IsWin { get; set; } = new();

        public int ScoreInfoId { get; set; }
        [ForeignKey("ScoreInfoId")]
        public PlayerScoreInfo ScoreInfo { get; set; } = new();

        public int PlayerHeroId { get; set; }
        [ForeignKey("PlayerHeroId")]
        public PlayerHero PlayerHero { get; set; } = new();
    }
}