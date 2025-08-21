using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarvelRivalsApi.Models.Entities
{
    public class Transformation
    {
        [Key]
        public int Id { get; set; }
        public int TransformationId { get; set; }
        public string? Name { get; set; }

        public string? Icon { get; set; }

        public string? Health { get; set; }

        public string? MovementSpeed { get; set; }

        // Foreign key to Hero
        public int? HeroId { get; set; }

        [ForeignKey("HeroId")]
        public Hero? Hero { get; set; }
    }
}
