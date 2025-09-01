using MarvelRivalsApi.Models.API;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.Entities
{
    public class PlayerStat
    {
        [Key]
        public int Id { get; set; }

        public long Uid { get; set; }

        public string Name { get; set; } = string.Empty;

        //Nav properties
        public int PlayerUpdatesId { get; set; }
        [ForeignKey("PlayerUpdatesId")]
        public PlayerUpdates Updates { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public Player Player { get; set; }

        public int OverallStatsId { get; set; }

        [ForeignKey("OverallStatsId")]
        public PlayerOverallStats OverallStats { get; set; }
    }
}
