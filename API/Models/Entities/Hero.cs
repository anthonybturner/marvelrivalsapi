using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarvelRivals.Models.Entities
{
    public class Hero
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? Id { get; set; }
        
        public string? Name { get; set; }

        public string? RealName { get; set; }

        public string? ImageUrl { get; set; }

        public string? Role { get; set; }

        public string? AttackType { get; set; }

        public List<string>? Team { get; set; }

        public string? Difficulty { get; set; }
        public string? Bio { get; set; }

        public string? Lore { get; set; }

        public List<Transformation>? Transformations { get; set; }

        public List<Costume>? Costumes { get; set; }

        public List<Ability>? Abilities { get; set; }

    }

    public class Transformation
    {
        public int Id { get; set; }
        public string? TransformationsId { get; set; }
        public string? Name { get; set; }

        public string? Icon { get; set; }

        public string? Health { get; set; }

        public string? MovementSpeed { get; set; }


        // Foreign key to Hero
        public string? HeroId { get; set; }

    }
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

    public class AdditionalFields
    {
        [Key]
        public int Id { get; set; }
        public string? Key { get; set; }

        public string? Casting { get; set; }
        public string? EnergyCost { get; set; }

        public string? SpecialEffect { get; set; }

    }


}
