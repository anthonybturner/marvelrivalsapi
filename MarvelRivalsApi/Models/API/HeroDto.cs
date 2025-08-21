using System.Text.Json.Serialization;

namespace MarvelRivals.Models.API
{
    public class HeroDto
    {
        [JsonPropertyName("id")]
        public int HeroId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("real_name")]
        public string? RealName { get; set; }

        [JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; set; }

        [JsonPropertyName("role")]
        public string? Role { get; set; }

        [JsonPropertyName("attack_type")]
        public string? AttackType { get; set; }

        [JsonPropertyName("team")]
        public List<string>? Team { get; set; }

        [JsonPropertyName("difficulty")]
        public string? Difficulty { get; set; }

        [JsonPropertyName("bio")]
        public string? Bio { get; set; }

        [JsonPropertyName("lore")]
        public string? Lore { get; set; }

        [JsonPropertyName("transformations")]
        public List<TransformationDto>? Transformations { get; set; }

        [JsonPropertyName("costumes")]
        public List<CostumeDto>? Costumes { get; set; }

        [JsonPropertyName("abilities")]
        public List<AbilityDto>? Abilities { get; set; }
    }
}