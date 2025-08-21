using System.Text.Json.Serialization;

namespace MarvelRivals.Models.API { 


    public class AbilityDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("isCollab")]
        public bool IsCollab { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("additional_fields")]
        public Dictionary<string, string>? AdditionalFields { get; set; }

        [JsonPropertyName("transformation_id")]
        public string? TransformationId { get; set; }
        // Foreign key to Hero
        public int HeroId { get; set; }
    }
    
}
