
using MarvelRivals.Data;
using MarvelRivalsApi.Data.Repositories.MatchHistory;
using MarvelRivalsApi.Models.API;
using MarvelRivalsApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarvelRivalsApi.Data.Repositories.Matchhistory
{
    public class MatchHistoryRepository : IMatchHistoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public MatchHistoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Models.Entities.MatchHistory>> GetAllAsync()
        {
            return await dbContext.MatchHistory.Include(mh => mh.MatchPlayer).ToListAsync();
        }

        public async Task<IEnumerable<Models.Entities.MatchHistory>> GetAllAsync(long playerUid)
        {
            return await dbContext.MatchHistory
                .Include(mh => mh.MatchPlayer)
                    .ThenInclude(mp => mp != null ? mp.PlayerHero : null)
                .Include(mh => mh.MatchPlayer)
                    .ThenInclude(mp => mp != null ? mp.ScoreInfo : null)
                .Include(mh => mh.ScoreInfo)
                .Select(mh => mh)
                .Where(mh => mh.MatchPlayer != null && mh.MatchPlayer.PlayerUid == playerUid)
                .ToListAsync();
        }

        public async Task<Models.Entities.MatchHistory?> GetByIdAsync(string matchUid)
        {
            return await dbContext.MatchHistory.FirstOrDefaultAsync(mh => mh.MatchUid == matchUid);
        }

     
        public async Task AddAsync(Models.Entities.MatchHistory matchHistory)
        {
            await dbContext.MatchHistory.AddAsync(matchHistory); // Use AddAsync instead of Add
        }

        public async Task AddRangeAsync(IEnumerable<Models.Entities.MatchHistory> matchHistory)
        {
            await dbContext.MatchHistory.AddRangeAsync(matchHistory);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string matchUid)
        {
            var match = await dbContext.MatchHistory.FirstOrDefaultAsync(mh => mh.MatchUid == matchUid);
            if (match != null)
            {
                dbContext.MatchHistory.Remove(match);
            }
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Update(Models.Entities.MatchHistory matchHistory)
        {
            dbContext.Update(matchHistory);
        }

        public async Task<long?> GetPlayerUidAsync(string playerName)
        {
            return await dbContext.MatchHistory
                .Where(mh => mh.MatchPlayer != null && mh.MatchPlayer.PlayerName == playerName)
                .Select(mh => mh.MatchPlayer != null ? mh.MatchPlayer.PlayerUid : null)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> HasMatchHistoryAsync(string matchUid)
        {
            return await dbContext.MatchHistory.AnyAsync(mh => mh.MatchUid == matchUid);
        }

        public async Task<List<long?>> GetPlayersUidsAsync()
        {
            return await dbContext.MatchHistory
                .Select(mh => mh.MatchPlayer != null ? mh.MatchPlayer.PlayerUid : null)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<PlayerInfoDto>> GetPlayersInfoAsync()
        {
            return await dbContext.MatchHistory
                .Select(mh => new PlayerInfoDto
                {
                    PlayerName = mh.MatchPlayer != null ? mh.MatchPlayer.PlayerName : string.Empty, // Ensure non-null value
                    PlayerUid = (long)(mh.MatchPlayer != null ? mh.MatchPlayer.PlayerUid : null),   // Ensure non-null value
                })
                .Distinct()
                .ToListAsync();
        }
    }
}