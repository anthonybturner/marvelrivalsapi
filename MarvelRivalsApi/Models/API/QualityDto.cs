using System.Text.Json.Serialization;

namespace MarvelRivals.Models.API
{
    public class QualityDto
    {
          
        [JsonPropertyName("name")]
        public string? Name { get; set; }
            
        [JsonPropertyName("color")]
        public string? Color { get; set; }
            
        [JsonPropertyName("value")]
        public int? Value { get; set; }

            
        [JsonPropertyName("icon")]
        public string? Icon { get; set; }
    }
}