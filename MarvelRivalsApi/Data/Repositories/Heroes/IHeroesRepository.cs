using MarvelRivals.Models.API;
using MarvelRivalsApi.Models.Entities;

namespace MarvelRivals.Data.Repositories.Heroes
{
    public interface IHeroesRepository
    {
        Task<IEnumerable<Hero>> GetAllAsync();
        Task<Hero?> GetByIdAsync(string id);
        Task<List<Hero>> GetByIdsAsync(IEnumerable<string> ids);

        Task AddAsync(Hero hero);

        void Update(Hero hero);
        Task DeleteAsync(string id);
        Task AddRangeAsync(IEnumerable<Hero> heroes);

        Task SaveChangesAsync();
    }
}
