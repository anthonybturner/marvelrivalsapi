using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class PlayerUpdatesDto
    {

        [JsonPropertyName("info_update_time")]
        public string InfoUpdateTime { get; set; }

        [JsonPropertyName("last_history_update")]
        public string LastHistoryUpdate { get; set; }

        [JsonPropertyName("last_inserted_match")]
        public string LastInsertedMatch { get; set; }

        [JsonPropertyName("last_update_request")]
        public string LastUpdateRequest { get; set; }

    }
}