using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


        // Foreign key to Hero
        public int? AdditionalFieldsId { get; set; }

        [ForeignKey("AdditionalFieldsId")]
        public AdditionalFields? AdditionalFields { get; set; }

        public int? HeroId { get; set; }

    }

}
