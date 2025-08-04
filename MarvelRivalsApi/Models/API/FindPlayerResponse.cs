using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class FindPlayerResponse
    {
        [JsonPropertyName("uid")]
        public string? PlayerUid { get; set; }

        [JsonPropertyName("name")]
        public string? PlayerName { get; set; }
    }
}
