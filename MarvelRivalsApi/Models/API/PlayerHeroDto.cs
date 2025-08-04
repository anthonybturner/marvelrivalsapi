using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class PlayerHeroDto
    {
        public int Id { get; set; }

        [JsonPropertyName("hero_id")]
        public int? HeroId { get; set; }

        [JsonPropertyName("hero_name")]
        public string? HeroName { get; set; } = string.Empty;

        [JsonPropertyName("hero_type")] 
        public string? HeroType { get; set; } = string.Empty;

        [JsonPropertyName("kills")]
        public int? Kills { get; set; }

        [JsonPropertyName("deaths")]
        public int? Deaths { get; set; }

        [JsonPropertyName("assists")]
        public int? Assists { get; set; }

        [JsonPropertyName("play_time")]
        public double? PlayTime { get; set; }

        [JsonPropertyName("total_hero_damage")]
        public double? TotalHeroDamage { get; set; }

        [JsonPropertyName("total_damage_taken")]
        public double? TotalDamageTaken { get; set; }
       
        [JsonPropertyName("total_hero_heal")]
        public double? TotalHeroHeal { get; set; }
    }
}
