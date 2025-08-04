using System.Runtime;

namespace MarvelRivalsApi.Models.Entities
{
    public class MatchPlayer
    {
        public int Id { get; set; } // Primary key
        public int Assists { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public WinInfo IsWin { get; set; } = new();
        public bool Disconnected { get; set; }
        public int PlayerUid { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public int? Camp { get; set; }
        public PlayerScoreInfo ScoreInfo { get; set; } = new();
        public PlayerHero PlayerHero { get; set; } = new();
    }
}
