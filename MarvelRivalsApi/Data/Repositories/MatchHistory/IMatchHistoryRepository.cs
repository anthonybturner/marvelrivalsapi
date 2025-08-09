using MarvelRivalsApi.Models.API;
using MarvelRivalsApi.Models.Entities;

namespace MarvelRivalsApi.Data.Repositories.MatchHistory
{
    public interface IMatchHistoryRepository
    {
        Task<IEnumerable<Models.Entities.MatchHistory>> GetAllAsync();
        Task<IEnumerable<Models.Entities.MatchHistory>> GetAllAsync(long playerUid);
        Task<Models.Entities.MatchHistory?> GetByIdAsync(string matchUid);

        Task AddAsync(Models.Entities.MatchHistory matchHistory);

        void Update(Models.Entities.MatchHistory matchHistory);
        Task DeleteAsync(string matchUid);
        Task AddRangeAsync(IEnumerable<Models.Entities.MatchHistory> matchHistory);

        Task SaveChangesAsync();

        Task<long?> GetPlayerUidAsync(string playerName);
        Task<List<long?>> GetPlayersUidsAsync();

        Task<bool> HasMatchHistoryAsync(string matchUid);
        Task<List<PlayerInfoDto>> GetPlayersInfoAsync();
    }
}
