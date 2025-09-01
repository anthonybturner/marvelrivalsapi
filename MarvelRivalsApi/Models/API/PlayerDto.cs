using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class PlayerDto
    {

        [JsonPropertyName("uid")]
        public long Uid { get; set; }

        [JsonPropertyName("level")]
        public string level { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("icon")]
        public PlayerIconDto Icon { get; set; }

        [JsonPropertyName("rank")]
        public PlayerRankDto Rank{ get; set; }

        [JsonPropertyName("team")]
        public PlayerTeamDto Team{ get; set; }

        [JsonPropertyName("info")]
        public PlayerInfoDto Info { get; set; }
    }
}