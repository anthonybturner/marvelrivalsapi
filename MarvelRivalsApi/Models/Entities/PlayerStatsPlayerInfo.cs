using System.ComponentModel.DataAnnotations;

namespace MarvelRivalsApi.Models.Entities
{
    public class PlayerStatsPlayerInfo
    {
        [Key]
        public int Id { get; set; }
        public long? PlayerUid { get; set; }
        public string PlayerName { get; set; }
    }
}
