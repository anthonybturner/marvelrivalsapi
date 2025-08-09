using MarvelRivals.Models.API;
using MarvelRivalsApi.Models.API;

namespace MarvelRivalsApi.Services.MatchHistoryService
{
    public interface IMatchHistoryService
    {
        public Task<MatchHistoryResponseDto> FetchAllAsync(long playerUid, string playerName);
        public Task<FindPlayerResponse?> FetchPlayerUid(string playerName);
    }
}
