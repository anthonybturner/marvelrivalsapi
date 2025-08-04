namespace MarvelRivalsApi.Models.Entities
{
    public class MatchHistory
    {
        public int Id { get; set; } // Primary key
        public int MatchMapId { get; set; }
        public string MatchMapName { get; set; } = string.Empty;
        public string MapThumbnail { get; set; } = string.Empty;
        public double MatchPlayDuration { get; set; }
        public string MatchSeason { get; set; } = string.Empty;
        public string MatchUid { get; set; } = string.Empty;
        public int MatchWinnerSide { get; set; }
        public int MvpUid { get; set; }
        public int SvpUid { get; set; }
        public ScoreInfo? ScoreInfo { get; set; }
        public long MatchTimeStamp { get; set; }
        public int PlayModeId { get; set; }
        public int GameModeId { get; set; }
        public MatchPlayer MatchPlayer { get; set; } = new();
        public string? MatchPlayerUid { get; set; }
        public string? MatchPlayerName { get; set; }
    }
}