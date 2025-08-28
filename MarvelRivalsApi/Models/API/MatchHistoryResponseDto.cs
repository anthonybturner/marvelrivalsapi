using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class MatchHistoryResponseDto
    {
        [JsonPropertyName("match_history")]
        public List<MatchHistoryDto> MatchHistory { get; set; } = new List<MatchHistoryDto> ();
         public PaginationDto Pagination { get; set; } = new();
    }
}
