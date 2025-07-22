using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace MarvelRivalsApiAPI.Models
{
    public class GameMap
    {

        [Key]
        public int Id { get; set; }
        [JsonPropertyName("id")]
        public int MapId { get; set; }
        
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("full_name")]
        public string? FullName { get; set; }

        [JsonPropertyName("locaton")]
        public string? Location { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("game_mode")]
        public string? GameMode { get; set; }

        [JsonPropertyName("is_competitive")]
        public bool? IsCompetitve { get; set; }

        [JsonPropertyName("sub_map")]
        public SubMap? SubMap { get; set; }

        [JsonPropertyName("video")]
        public string? Video { get; set; }

        [JsonPropertyName("images")]
        public string[] Images { get; set; }
    }

    public class SubMap
    {

        [Key]
        public int id;

        [JsonPropertyName("id")]
        public int? SubMapId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("thumbnail")]
        public string? Thumbnail { get; set; }
    }
}