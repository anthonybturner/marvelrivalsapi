using MarvelRivals.Data;
using MarvelRivals.Data.Repositories.Maps;
using MarvelRivalsApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarvelRivalsApi.Data.Repositories.Maps
{
    public class GameMapsRepository(ApplicationDbContext context) : IGameMapsRepository
    {
        public async Task<IEnumerable<GameMap>> GetAllAsync()
        {
            return await context.GameMaps.ToListAsync();
        }

        public async Task<GameMap?> GetByIdAsync(int id)
        {
            return await context.GameMaps.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(GameMap map)
        {
            await context.GameMaps.AddAsync(map);
        }

        public async Task AddRangeAsync(List<GameMap> maps)
        {
            await context.GameMaps.AddRangeAsync(maps);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var map = await context.GameMaps.FindAsync(id);
            if (map != null)
            {
                context.GameMaps.Remove(map);
            }
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(Hero hero)
        {
            context.Heroes.Update(hero);
        }
    }
}
