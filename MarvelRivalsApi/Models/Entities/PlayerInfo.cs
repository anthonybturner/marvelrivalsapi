using System.ComponentModel.DataAnnotations;

namespace MarvelRivalsApi.Models.Entities
{
    public class PlayerInfo
    {
        [Key]
        public int Id { get; set; }
        public long PlayerUid { get; set; }
        public string PlayerName { get; set; }
    }
}