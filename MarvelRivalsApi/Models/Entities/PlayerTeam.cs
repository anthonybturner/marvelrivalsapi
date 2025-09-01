using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.Entities
{
    public class PlayerTeam
    {
        [Key]
        public int Id { get; set; }
        public string ClubTeamId { get; set; }

        public string ClubTeamMiniName { get; set; } = string.Empty;

        public string ClubTeamType { get; set; } = string.Empty;
    }
}