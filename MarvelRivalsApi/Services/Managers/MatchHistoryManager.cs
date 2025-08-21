using MarvelRivalsApi.Data.Repositories.MatchHistory;
using MarvelRivalsApi.Mappings;
using MarvelRivalsApi.Models.API;
using MarvelRivalsApi.Services.MatchHistoryService;

namespace MarvelRivalsApi.Services.Managers
{
    public class MatchHistoryManager(IMatchHistoryService matchHistoryService, IMatchHistoryRepository matchHistoryRepository)
    {
        public async Task InitAsync(long playerUid, string playerName)
        {
            await FetchAllMatchesAndSaveToDatabaseAsync(playerUid, playerName);
        }

        public async Task FetchAllMatchesAndSaveToDatabaseAsync(long playerUid, string playerName)
        {
            try
            {
                MatchHistoryResponseDto response = await matchHistoryService.FetchAllAsync(playerUid, playerName);
                if (response != null && response.MatchHistory.Count > 0)
                {
                    List<Models.Entities.MatchHistory> matchHistories = [];
                    foreach (var match in response.MatchHistory)
                    {
                        matchHistories.Add(MatchHistoryMapper.ToEntity(match));
                    }
                    await matchHistoryRepository.AddRangeAsync(matchHistories);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching matches for the given player uid {playerUid} and player name {playerName}", ex);
            }
        }

        public async Task<long> GetPlayerUid(string playerName)
        {
            try
            {
                long? playerUid = await matchHistoryRepository.GetPlayerUidAsync(playerName);
                playerUid ??= await FetchPlayerUid(playerName);
                return playerUid.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching player UID", ex);
            }
        }

        public async Task<long?> FetchPlayerUid(string playerName)
        {
            try
            {
                var response = await matchHistoryService.FetchPlayerUid(playerName);
                if (response == null || response.PlayerUid == null)
                {
                    throw new Exception("Player UID could not be fetched.");
                }
                if (long.TryParse(response.PlayerUid, out long uid))
                {
                    return uid;
                }
                return null;
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
                if (pInfo.PlayerUid != null && !string.IsNullOrEmpty(pInfo.PlayerName))
                {
                    var latestMatches = await matchHistoryService.FetchAllAsync(pInfo.PlayerUid.Value, pInfo.PlayerName);
                    foreach (var match in latestMatches.MatchHistory)
                    {
                        bool exists = await matchHistoryRepository.HasMatchHistoryAsync(match.MatchUid);
                        if (!exists)
                        {
                            var entity = MatchHistoryMapper.ToEntity(match);
                            await matchHistoryRepository.AddAsync(entity);
                        }
                    }
                }
            }
            await matchHistoryRepository.SaveChangesAsync();
        }


    }
}
