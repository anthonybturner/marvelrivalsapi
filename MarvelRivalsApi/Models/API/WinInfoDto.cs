using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class WinInfoDto
    {
        public int Score { get; set; }

        [JsonPropertyName("is_win")]
        public bool IsWin { get; set; }
    }
}
