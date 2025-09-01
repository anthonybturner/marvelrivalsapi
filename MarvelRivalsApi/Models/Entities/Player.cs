using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.Entities
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public long Uid { get; set; }

        public string level { get; set; }

        public string Name { get; set; }

        //Nav properties
        public int PlayerIconId { get; set; }

        [ForeignKey("PlayerIconId")]
        public PlayerIcon Icon { get; set; }

        public int PlayerRankId { get; set; }
        //Nav properties
        [ForeignKey("PlayerRankId")]
        public PlayerRank Rank { get; set; }

        public int PlayerTeamId { get; set; }
        //Nav properties
        [ForeignKey("PlayerTeamId")]
        public PlayerTeam Team { get; set; }

        public int PlayerStatsPlayerInfoId { get; set; }
        //Nav properties
        [ForeignKey("PlayerStatsPlayerInfoId")]
        public PlayerStatsPlayerInfo Info { get; set; }
    }
}