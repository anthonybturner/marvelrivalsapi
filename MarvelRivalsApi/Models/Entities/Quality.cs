using System.ComponentModel.DataAnnotations;

namespace MarvelRivalsApi.Models.Entities
{
    public class Quality
    {
        [Key]
        public int Id { get; set; } 

        public string? Name
        { get; set; }
        public string? Color { get; set; }
        public int? Value { get; set; }
        public string? Icon { get; set; }
    }
}