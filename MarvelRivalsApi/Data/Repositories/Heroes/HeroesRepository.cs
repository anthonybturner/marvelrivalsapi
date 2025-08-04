using MarvelRivals.Models.API;
using MarvelRivalsApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MarvelRivals.Data.Repositories.Heroes
{
    public class HeroesRepository(ApplicationDbContext context) : IHeroesRepository
    {
        public async Task<IEnumerable<Hero>> GetAllAsync()
        {
            return await context.Heroes
                .Include(h => h.Abilities)
                .Include(h => h.Transformations)
                .Include(h => h.Costumes)
                .ToListAsync();
        }

        public async Task<Hero?> GetByIdAsync(string id)
        {
            return await context.Heroes
                .Include(h => h.Abilities)
                .Include(h => h.Transformations)
                .Include(h => h.Costumes)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<List<Hero>> GetByIdsAsync(IEnumerable<string> ids)
        {
            return await context.Heroes
                .Include(h => h.Abilities)
                .Include(h => h.Transformations)
                .Include(h => h.Costumes)
                .Where(h => ids.Contains(h.Id))
                .ToListAsync();
        }

        public async Task AddAsync(Hero hero)
        {
            await context.Heroes.AddAsync(hero); // Use AddAsync instead of Add
        }

        public void Update(Hero hero)
        {
            context.Heroes.Update(hero);
        }

        public async Task DeleteAsync(string id)
        {
            var hero = await context.Heroes.FindAsync(id);
            if (hero != null)
            {
                context.Heroes.Remove(hero);
            }
        }

        public async Task AddRangeAsync(IEnumerable<Hero> heroes)
        {
            await context.Heroes.AddRangeAsync(heroes);
            await context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}