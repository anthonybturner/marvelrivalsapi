using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.Entities
{
    public class ScoreInfo
    {
        [Key]
        public int Id { get; set;  }

        [JsonPropertyName("0")]
        public int Zero { get; set; }

        [JsonPropertyName("1")]
        public int One { get; set; }
    }
}
