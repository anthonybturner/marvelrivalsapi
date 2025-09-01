using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.Entities
{
    public class PlayerIcon
    {
        [Key]
        public int Id { get; set; }
        public string IconId { get; set; }
        public string Icon { get; set; } = string.Empty;
    }
}