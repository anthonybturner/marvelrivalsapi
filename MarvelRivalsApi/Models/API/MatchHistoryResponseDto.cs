using System.Text.Json.Serialization;

namespace MarvelRivalsApi.Models.API
{
    public class MatchHistoryResponseDto
    {
        [JsonPropertyName("match_history")]
        public List<MatchHistoryDto> MatchHistory { get; set; } = [];
         public PaginationDto Pagination { get; set; } = new();
    }
}
