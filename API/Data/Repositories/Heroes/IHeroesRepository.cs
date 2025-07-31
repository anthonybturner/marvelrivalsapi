using MarvelRivals.Models.API;
using MarvelRivals.Models.Entities;

namespace MarvelRivals.Data.Repositories.Heroes
{
    public interface IHeroesRepository
    {
        Task<IEnumerable<Hero>> GetAllAsync();
        Task<Hero> GetByIdAsync(string id);
        Task AddAsync(Hero hero);
        Task DeleteAsync(string id);
        Task AddRangeAsync(IEnumerable<Hero> heroes);
    }
}
