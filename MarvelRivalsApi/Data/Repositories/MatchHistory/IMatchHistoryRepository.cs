using MarvelRivalsApi.Models.API;
using MarvelRivalsApi.Models.Entities;

namespace MarvelRivalsApi.Data.Repositories.MatchHistoryRepositories
{
    public interface IMatchHistoryRepository
    {
        Task<IEnumerable<MatchHistory>> GetAllAsync();
        Task<IEnumerable<MatchHistory>> GetAllAsync(string matchUid);
        Task<MatchHistory?> GetByIdAsync(int id);
        Task<List<MatchHistory>> GetByIdsAsync(IEnumerable<int> ids);

        Task AddAsync(MatchHistory matchHistory);

        void Update(MatchHistory matchHistory);
        Task DeleteAsync(int id);
        Task AddRangeAsync(IEnumerable<MatchHistory> matchHistory);

        Task SaveChangesAsync();
        string? GetPlayerUid(string playerName);
        Task<bool> HasMatchHistory(string matchUid);
        Task<List<string?>> GetPlayersUidsAsync();
        Task<List<PlayerInfoDto>> GetPlayersInfoAsync();
    }
}
