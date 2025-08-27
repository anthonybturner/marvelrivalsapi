using System.ComponentModel.DataAnnotations;
using System.Security;
using System.Text.Json.Serialization;

namespace MarvelRivals.Models.API
{
    public class AdditionalFieldsDto
    {

        [Key]
        public int Id { get; set; }

        [JsonPropertyName("Key")]
        public string? Key { get; set; }

        [JsonPropertyName("Energy Cost")]
        public string? EnergyCost { get; set; }

        [JsonPropertyName("Maximum Energy")]
        public string? MaximumEnergy { get; set; }

        [JsonPropertyName("Movement Boost")]
        public string? MovementBoost { get; set; }

        [JsonPropertyName("Energy Recovery Speed")]
        public string? EnergyRecoverySpeed { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object>? ExtraFields { get; set; }
    }
}