using MarvelRivals.Models.API;
using MarvelRivalsApi.Models.API;

namespace MarvelRivalsApi.Services.MatchHistoryService
{
    public interface IMatchHistoryService
    {
        public Task<MatchHistoryResponseDto> FetchAllAsync(string playerUid, string playerName);
        public Task<MatchHistoryDto> FetchByIdAsync(int id);
        public Task<string> FetchPlayerUid(string playerName);
    }
}
