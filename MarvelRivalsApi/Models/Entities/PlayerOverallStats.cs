using MarvelRivalsApi.Models.API;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.Entities
{
    public class PlayerOverallStats
    {
        [Key]
        public int Id { get; set; }

        public int TotalMatches { get; set; }
        public int TotalWins { get; set; }

        //Nav
        public int PlayerUnrankedId { get; set; }

        [ForeignKey("PlayerUnrankedId")]
        public PlayerUnranked Unranked { get; set; }

        public int PlayerRankedId { get; set; }

        [ForeignKey("PlayerRankedId")]
        public PlayerRanked Ranked { get; set; }

    }
}