using MarvelRivals.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarvelRivals.Data.Repositories.Maps
{
    public class GameMapsRepository : IGameMapsRepository
    {
        private readonly ApplicationDbContext _context;

        public GameMapsRepository(ApplicationDbContext context) { 
            _context = context; 

        }

        public async Task<IEnumerable<GameMap>> GetAllAsync()
        {
            return await _context.GameMaps.ToListAsync();
        }

        public async Task<GameMap?> GetByIdAsync(int id)
        {
            return await _context.GameMaps.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(GameMap map)
        {
            _context.GameMaps.Add(map);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(List<GameMap> maps)
        {
            await _context.GameMaps.AddRangeAsync(maps);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var map = await _context.GameMaps.FindAsync(id);
            if (map != null)
            {
                _context.GameMaps.Remove(map);
                await _context.SaveChangesAsync();
            }
        }
    }
}
