using MarvelRivalsApi.Data.Repositories.MatchHistoryRepositories;
using MarvelRivalsApi.Mappings;
using MarvelRivalsApi.Models.API;
using MarvelRivalsApi.Services.MatchHistoryService;
using Microsoft.EntityFrameworkCore;

namespace MarvelRivalsApi.Services.Managers
{
    public class MatchHistoryManager(IMatchHistoryService matchHistoryService, IMatchHistoryRepository matchHistoryRepository)
    {
        public async Task InitAsync(string playerUid, string playerName)
        {
            await FetchAllMatchesAndSaveToDatabaseAsync(playerUid, playerName);
        }

        public async Task FetchAllMatchesAndSaveToDatabaseAsync(string playerUid, string playerName)
        {
            try
            {
                MatchHistoryResponseDto response = await matchHistoryService.FetchAllAsync(playerUid, playerName);
                if (response == null || response.MatchHistory.Count() <= 0) return;

                List<MarvelRivalsApi.Models.Entities.MatchHistory> matchHistories = new();
                foreach (var match in response.MatchHistory)
                {
                    matchHistories.Add(MatchHistoryMapper.ToEntity(match));
                }
                await matchHistoryRepository.AddRangeAsync(matchHistories);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching all maps", ex);
            }
        }

        public async Task<string> FetchPlayerUid(string playerName)
        {
            try
            {
                return await matchHistoryService.FetchPlayerUid(playerName);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching player UID", ex);
            }
        }

        public async Task SyncMatchHistoryToDatabaseAsync()
        {
            // Pseudocode for periodic sync
            List<PlayerInfoDto> playerInfo = await matchHistoryRepository.GetPlayersInfoAsync();

            foreach (var pInfo in playerInfo)
            {
                // Ensure playerUid and playerName are not null before calling FetchAllAsync
                if (string.IsNullOrEmpty(pInfo.PlayerUid) || string.IsNullOrEmpty(pInfo.PlayerName))
                {
                    // Skip processing if either value is null or empty
                    continue;
                }
                var latestMatches = await matchHistoryService.FetchAllAsync(playerUid: pInfo.PlayerUid, pInfo.PlayerName);
                foreach (var match in latestMatches.MatchHistory)
                {
                    bool exists = await matchHistoryRepository.HasMatchHistory(match.MatchUid);
                    if (!exists)
                    {
                        var entity = MatchHistoryMapper.ToEntity(match);
                        await matchHistoryRepository.AddAsync(entity);
                    }
                }
            }
            await matchHistoryRepository.SaveChangesAsync();
        }


    }
}
