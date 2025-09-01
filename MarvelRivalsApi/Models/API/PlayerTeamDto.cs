using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class PlayerTeamDto
    {

        [JsonPropertyName("club_team_id")]
        public string ClubTeamId { get; set; }

        [JsonPropertyName("club_team_mini_name")]
        public string ClubTeamMiniName { get; set; } = string.Empty;

        [JsonPropertyName("club_team_type")]
        public string ClubTeamType { get; set; } = string.Empty;
    }
}