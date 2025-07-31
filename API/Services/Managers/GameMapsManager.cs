using MarvelRivals.Data;
using MarvelRivals.Data.Repositories.Maps;
using MarvelRivals.Mappings;
using MarvelRivals.Models.API;
using MarvelRivals.Services.GameMaps;

namespace MarvelRivals.Services.Managers
{
    public class GameMapsManager
    {
        private readonly IGameMapsService _gameMapsService;
        private readonly GameMapsRepository _gameMapsRepository;

        public GameMapsManager(IGameMapsService gameMapsService, GameMapsRepository gameMapsRepository)
        {
            _gameMapsService = gameMapsService;
            _gameMapsRepository = gameMapsRepository;
        }

        public async Task FetchAllMapsAndSaveToDatabaseAsync()
        {
            try
            {
                GameMapDto response = await _gameMapsService.FetchAllAsync();
                if (response?.Maps == null || !response.Maps.Any()) return;
                List <Models.Entities.GameMap> gameMaps = new List<Models.Entities.GameMap>();
                for (var i = 0; i < response.Maps.Count; i++)
                {
                    gameMaps.Add(GameMapsMapper.ToEntity(response.Maps[i]));
                }
               await _gameMapsRepository.AddRangeAsync(gameMaps);

            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, etc.
                throw new Exception("Error fetching all maps", ex);
            }
        }

    }
}
