using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class PlayerIconDto
    {

        [JsonPropertyName("player_icon_id")]
        public string IconId { get; set; }

        [JsonPropertyName("player_icon")]
        public string Icon { get; set; } = string.Empty;
    }
}