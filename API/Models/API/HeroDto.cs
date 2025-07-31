using System.Text.Json.Serialization;

namespace MarvelRivals.Models.API
{
    public class HeroDto
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

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

        //[JsonPropertyName("team")]
        //public List<string> Team { get; set; }

        [JsonPropertyName("difficulty")]
        public string? Difficulty { get; set; }

        [JsonPropertyName("bio")]
        public string? Bio { get; set; }

        [JsonPropertyName("lore")]
        public string? Lore { get; set; }

        [JsonPropertyName("transformations")]
        public List<Transformation>? Transformations { get; set; }

        [JsonPropertyName("costumes")]
        public List<Costume>? Costumes { get; set; }

        [JsonPropertyName("abilities")]
        public List<Ability>? Abilities { get; set; }

        public class Transformation
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

        public class Costume
        {
            [JsonPropertyName("id")]
            public string? Id { get; set; }

            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonPropertyName("icon")]
            public string? Icon { get; set; }

            [JsonPropertyName("quality")]
            public string? Quality { get; set; }

            [JsonPropertyName("description")]
            public string? Description { get; set; }

            [JsonPropertyName("appearance")]
            public string? Appearance { get; set; }
        }

        public class Ability
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
        }
    }
}