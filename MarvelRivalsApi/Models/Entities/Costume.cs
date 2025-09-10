using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarvelRivalsApi.Models.Entities
{

    public class Costume
    {
        [Key]
        public int Id { get; set; }
        public int CostumeId { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? Description { get; set; }
        public string? Appearance { get; set; }


        //Navigation Properties
      
        // Foreign key to Hero
        public int? HeroId { get; set; }

        public int? QualityId { get; set; }

        [ForeignKey("QualityId")]
        public Quality? Quality { get; set; }

    }
}