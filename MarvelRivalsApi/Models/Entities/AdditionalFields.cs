using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarvelRivalsApi.Models.Entities
{
    public class AdditionalFields
    {
        [Key]
        public int Id { get; set; }
        public string? Key { get; set; }
        public string? Casting { get; set; }
        public string? EnergyCost { get; set; }
        public string? MaximumEnergy { get; set; }
        public string? MovementBoost { get; set; }
        public string? EnergyRecoverySpeed { get; set; }
        public string? SpecialEffect { get; set; }
        public string? ExtraFieldsJson { get; set; }

        //Navigation property to Ability
        [ForeignKey("AbilityId")]
        public int? AbilityId { get; set; }
        public Ability? Ability { get; set; }
    }
}
