using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace MarvelRivalsFanSiteDotNet.Models
{
    public class Hero
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("real_name")]
        public string RealName { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("attack_type")]
        public string AttackType { get; set; }

        [JsonProperty("team")]
        public List<string> Team { get; set; } = new List<string>();

        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("lore")]
        public string Lore { get; set; }

        [JsonProperty("transformations")]
        public List<Transformation> Transformations { get; set; } = new List<Transformation>();


        [JsonProperty("abilities")]
        public List<HeroAbility> Abilities { get; set; } = new List<HeroAbility>();
    }

    public class Transformation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("health")]
        public string Health { get; set; }

        [JsonProperty("movement_speed")]
        public string MovementSpeed { get; set; }
    }

    public class HeroAbility
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("icon")]
        public string IconUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public AbilityType Type { get; set; }

        [JsonProperty("isCollab")]
        public bool IsCollab { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("additional_fields")]
        public Dictionary<string, object> AdditionalFields { get; set; } = new Dictionary<string, object>();

        [JsonProperty("transformation_id")]
        public string TransformationId { get; set; }
    }

    public enum AbilityType
    {
        [JsonProperty("Ultimate")]
        Ultimate,

        [JsonProperty("Normal")]
        Normal,

        [JsonProperty("Weapon")]
        Weapon,

       [JsonProperty("Passive")]
        Passive  // Add this new value
    }
}