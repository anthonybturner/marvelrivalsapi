using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.Entities
{
    public class PlayerRank
    {
        [Key]
        public int Id { get; set; }
        public string Rank { get; set; }

        public string Image { get; set; }
        public string Color { get; set; }
    }
}