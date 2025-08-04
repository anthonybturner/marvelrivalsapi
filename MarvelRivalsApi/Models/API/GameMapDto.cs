using System.Text.Json.Serialization;

namespace MarvelRivals.Models.API
{
    public class GameMapDto
    {
 
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("full_name")]
        public string? FullName { get; set; }

        [JsonPropertyName("location")]
        public string? Location { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("game_mode")]
        public string? GameMode { get; set; }

        [JsonPropertyName("is_competitive")]
        public bool IsCompetitive { get; set; }

        [JsonPropertyName("sub_map")]
        public SubMap? SubMap { get; set; }

        [JsonPropertyName("video")]
        public string? Video { get; set; }

        [JsonPropertyName("images")]
        public List<string>? Images { get; set; }
       
    }
}
