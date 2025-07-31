using MarvelRivals.Models.API;
using MarvelRivals.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarvelRivals.Data.Repositories.Heroes
{
    public class HeroesRepository : IHeroesRepository
    {

        private readonly ApplicationDbContext _context;

        public HeroesRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Hero>> GetAllAsync()
        {
            return await _context.Heroes
                .Include(h => h.Abilities)
                .Include(h => h.Transformations)
                .Include(h => h.Costumes)
                .ToListAsync(); 
        }


        public async Task<Hero?> GetByIdAsync(string id)
        {
            return await _context.Heroes
                .Include(h => h.Abilities)
                .Include(h => h.Transformations)
                .Include(h => h.Costumes)
                .FirstOrDefaultAsync(h => h.Id == id);
        }


        public async Task AddAsync(Hero hero)
        {
            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero != null)
            {
                _context.Heroes.Remove(hero);
                await _context.SaveChangesAsync();
            }   
        }

        public async Task AddRangeAsync(IEnumerable<Hero> heroes)
        {
           await _context.Heroes.AddRangeAsync(heroes);
           await _context.SaveChangesAsync();
        }
    }
}
