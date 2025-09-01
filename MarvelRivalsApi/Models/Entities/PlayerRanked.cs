using System.ComponentModel.DataAnnotations;

namespace MarvelRivalsApi.Models.Entities
{
    public class PlayerRanked
    {
        [Key]
        public int Id { get; set; }
        public int TotalMatches { get; set; }
        public int TotalWins { get; set; }
        public int TotalAssists { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalKills { get; set; }
        public string TotalTimePlayed { get; set; }
        public float TotalTimePlayedRaw { get; set; }
        public int TotalMvp { get; set; }
        public int TotalSvp { get; set; }
    }
}