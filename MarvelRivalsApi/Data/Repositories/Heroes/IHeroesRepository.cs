using MarvelRivals.Models.API;
using MarvelRivalsApi.Models.Entities;

namespace MarvelRivals.Data.Repositories.Heroes
{
    public interface IHeroesRepository
    {
        Task<IEnumerable<Hero>> GetAllAsync();
        Task<Hero?> GetByIdAsync(int id);
        Task<List<Hero>> GetByIdsAsync(IEnumerable<int> ids);

        Task<Hero> GetByNameAsync(string name);

        Task AddAsync(Hero hero);

        void Update(Hero hero);
        Task DeleteAsync(int id);
        Task AddRangeAsync(IEnumerable<Hero> heroes);

        Task SaveChangesAsync();
    }
}
