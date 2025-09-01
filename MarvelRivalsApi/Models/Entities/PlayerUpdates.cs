using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.Entities
{
    public class PlayerUpdates
    {
        [Key]
        public int Id { get; set; }
        public string InfoUpdateTime { get; set; }

        public string LastHistoryUpdate { get; set; }

        public string LastInsertedMatch { get; set; }

        public string LastUpdateRequest { get; set; }
    }
}