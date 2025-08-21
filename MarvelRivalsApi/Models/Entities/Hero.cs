using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarvelRivalsApi.Models.Entities
{
    public class Hero
    {
        [Key]
        public int? Id { get; set; }

        public int HeroId { get; set; }
        
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

}
