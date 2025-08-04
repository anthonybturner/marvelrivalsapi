using System.Text.Json.Serialization;

namespace MarvelRivals.Models.API
{
    public class TransformationDto
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }

        [JsonPropertyName("health")]
        public string? Health { get; set; }

        [JsonPropertyName("movement_speed")]
        public string? MovementSpeed { get; set; }
    }
}
