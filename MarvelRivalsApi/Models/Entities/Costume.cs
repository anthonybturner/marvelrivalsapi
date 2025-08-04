using System.ComponentModel.DataAnnotations;

namespace MarvelRivalsApi.Models.Entities
{

    public class Costume
    {
        [Key]
        public int Id { get; set; }

        public string? CostumeId { get; set; }
        public string? Name { get; set; }

        public string? Icon { get; set; }

        public string? Quality { get; set; }

        public string? Description { get; set; }

        public string? Appearance { get; set; }

        // Foreign key to Hero
        public string? HeroId { get; set; }

    }
}