
using MarvelRivals.Data;
using MarvelRivalsApi.Models.API;
using MarvelRivalsApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarvelRivalsApi.Data.Repositories.MatchHistoryRepositories
{
    public class MatchHistoryRepository(ApplicationDbContext dbContext) : IMatchHistoryRepository
    {
        public async Task<IEnumerable<MatchHistory>> GetAllAsync()
        {
            return await dbContext.MatchHistory.ToListAsync();
        }

        public async Task<IEnumerable<MatchHistory>> GetAllAsync(string playerUid)
        {
            return await dbContext.MatchHistory
                .Include(mh => mh.MatchPlayer)
                    .ThenInclude(mp => mp.PlayerHero)
                .Include(mh => mh.MatchPlayer)
                    .ThenInclude(mp => mp.ScoreInfo)
                .Include(mh => mh.ScoreInfo)
                .Select(mh => mh)
                .Where(mh => mh.MatchPlayerUid == playerUid)
                .ToListAsync();
        }

        public async Task<MatchHistory?> GetByIdAsync(int id)
        {
            return await dbContext.MatchHistory.FirstOrDefaultAsync(mh => mh.Id == id);
        }

        public async Task<List<MatchHistory>> GetByIdsAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
        public async Task AddAsync(MatchHistory matchHistory)
        {
            await dbContext.MatchHistory.AddAsync(matchHistory); // Use AddAsync instead of Add
        }

        public async Task AddRangeAsync(IEnumerable<MatchHistory> matchHistory)
        {
            await dbContext.MatchHistory.AddRangeAsync(matchHistory);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var match = await dbContext.MatchHistory.FindAsync(id);
            if (match != null)
            {
                dbContext.MatchHistory.Remove(match);
            }
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Update(MatchHistory matchHistory)
        {
            dbContext.Update(matchHistory);
        }

        public string? GetPlayerUid(string playerName)
        {
            return dbContext.MatchHistory
                .Where(mh => mh.MatchPlayerName == playerName)
                .Select(mh => mh.MatchPlayerUid)
                .FirstOrDefault();
        }

        public Task<bool> HasMatchHistory(string matchUid)
        {
            return dbContext.MatchHistory.AnyAsync(mh => mh.MatchUid == matchUid);
        }

        public async Task<List<string?>> GetPlayersUidsAsync()
        {
            return await dbContext.MatchHistory
                .Select(mh => mh.MatchPlayerUid)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<PlayerInfoDto>> GetPlayersInfoAsync()
        {
            return await dbContext.MatchHistory
                .Select(mh => new PlayerInfoDto
                {
                    PlayerName = mh.MatchPlayerName ?? string.Empty, // Ensure non-null value
                    PlayerUid = mh.MatchPlayerUid ?? string.Empty,   // Ensure non-null value
                })
                .Distinct()
                .ToListAsync();
        }
    }
}
