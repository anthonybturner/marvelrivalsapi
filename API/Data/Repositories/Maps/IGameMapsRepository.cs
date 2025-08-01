using MarvelRivals.Models.API;
using MarvelRivals.Models.Entities;
using GameMap = MarvelRivals.Models.Entities.GameMap;

namespace MarvelRivals.Data.Repositories.Maps
{
    public interface IGameMapsRepository
    {

        Task<IEnumerable<GameMap>> GetAllAsync();
        Task<GameMap?> GetByIdAsync(int id);
        Task AddAsync(GameMap map);
        Task AddRangeAsync(List<GameMap> maps);
        Task DeleteAsync(string id);
        Task SaveChangesAsync();

        void Update(Hero hero);
    }
}
