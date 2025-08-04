using System.ComponentModel.DataAnnotations;

namespace MarvelRivalsApi.Models.Entities
{
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
