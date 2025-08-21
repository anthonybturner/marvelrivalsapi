using System.Text.Json.Serialization;

namespace MarvelRivals.Models.API
{
    public class CostumeDto
    {
        [JsonPropertyName("id")]
        public int CostumeId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }

        [JsonPropertyName("quality")]
        public QualityDto? Quality { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("appearance")]
        public string? Appearance { get; set; }

        public int HeroId { get; set; } // Foreign key to Hero
    }
}
