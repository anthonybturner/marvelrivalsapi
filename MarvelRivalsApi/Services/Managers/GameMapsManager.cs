using MarvelRivals.Data.Repositories.Maps;
using MarvelRivals.Mappings;
using MarvelRivals.Models.API;
using MarvelRivals.Services.GameMaps;
using MarvelRivalsApi.Models.Entities;

namespace MarvelRivals.Services.Managers
{
    public class GameMapsManager
    {
        private readonly IGameMapsService gameMapsService;
        private readonly IGameMapsRepository gameMapsRepository;

        public GameMapsManager(IGameMapsService gameMapsService, IGameMapsRepository gameMapsRepository)
        {
            this.gameMapsService = gameMapsService;
            this.gameMapsRepository = gameMapsRepository;
        }

        public async Task InitAsync()
        {
            await FetchAllMapsAndSaveToDatabaseAsync();
        }

        public async Task FetchAllMapsAndSaveToDatabaseAsync()
        {
            try
            {
                GameMapResponseDto response = await gameMapsService.FetchAllAsync();
                if (response?.Maps == null || response.Maps.Count <= 0) return;

                // Correct the type of the list to match the repository's expected type
                List<GameMap> gameMaps = new List<GameMap>();
                for (var i = 0; i < response.Maps.Count; i++)
                {
                    gameMaps.Add(GameMapsMapper.ToEntity(response.Maps[i]));
                }
                await gameMapsRepository.AddRangeAsync(gameMaps);
            }
            catch (Exception ex)    
            {
                // Handle exceptions, log errors, etc.
                throw new Exception("Error fetching all maps", ex);
            }
        }
    }
}