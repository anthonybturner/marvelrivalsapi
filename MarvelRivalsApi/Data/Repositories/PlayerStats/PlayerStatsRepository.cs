
using Microsoft.EntityFrameworkCore;

namespace MarvelRivalsApi.Data.Repositories.PlayerStats
{
    public class PlayerStatsRepository : IPlayerStatsRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PlayerStatsRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Models.Entities.PlayerStat?> GetByUIdAsync(long uid)
        {
            return await dbContext.PlayerStats
                .Include(p => p.OverallStats)
                .Include(p => p.Player)
                .Include(p => p.Updates)
                .FirstOrDefaultAsync(ps => ps.Uid == uid);
        }

     
        public async Task AddAsync(Models.Entities.PlayerStat PlayerStats)
        {
            await dbContext.PlayerStats.AddAsync(PlayerStats); // Use AddAsync instead of Add
        }

        public async Task AddRangeAsync(IEnumerable<Models.Entities.PlayerStat> PlayerStats)
        {
            await dbContext.PlayerStats.AddRangeAsync(PlayerStats);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(long uid)
        {
            var match = await dbContext.PlayerStats.FirstOrDefaultAsync(ps => ps.Uid == uid);
            if (match != null)
            {
                dbContext.PlayerStats.Remove(match);
            }
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Update(Models.Entities.PlayerStat PlayerStats)
        {
            dbContext.Update(PlayerStats);
        }
    }
}