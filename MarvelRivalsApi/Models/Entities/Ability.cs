using System.ComponentModel.DataAnnotations;

namespace MarvelRivalsApi.Models.Entities
{
    public class Ability
    {
        [Key]
        public int Id { get; set; }
        public int AbilityId { get; set; }
        public string? Icon { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public bool IsCollab { get; set; }
        public string? Description { get; set; }

        public AdditionalFields? AdditionalFields { get; set; }
        // Foreign key to Hero
        public string? HeroId { get; set; }

    }

}
