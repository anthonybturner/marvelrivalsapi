using MarvelRivalsApi.Models.API;
using MarvelRivalsApi.Models.Entities;

namespace MarvelRivalsApi.Data.Repositories.PlayerStats
{
    public interface IPlayerStatsRepository
    {
        Task<Models.Entities.PlayerStat?> GetByUIdAsync(long uid);

        Task AddAsync(Models.Entities.PlayerStat playerStats);

        void Update(Models.Entities.PlayerStat playerStats);
        Task DeleteAsync(long uid);
        Task AddRangeAsync(IEnumerable<Models.Entities.PlayerStat> playerStats);

        Task SaveChangesAsync();
    }
}
