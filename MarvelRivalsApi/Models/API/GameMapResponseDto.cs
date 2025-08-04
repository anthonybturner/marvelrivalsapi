using System.Text.Json.Serialization;

namespace MarvelRivals.Models.API
{
    public class GameMapResponseDto
    {
    
        [JsonPropertyName("maps")]
        public List<GameMapDto>? Maps { get; set; }

        [JsonPropertyName("total_maps")]
        public int TotalMaps { get; set; }
        
    }
}
