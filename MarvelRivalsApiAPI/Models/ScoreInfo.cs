using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarvelRivalsApiAPI.Models
{
    public class ScoreInfo
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("0")]
        public int Lose { get; set; }

        [JsonPropertyName("1")]
        public int Win { get; set; }
    }
}