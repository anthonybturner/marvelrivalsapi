using MarvelRivals.Data.Repositories.Heroes;
using MarvelRivals.Mappings;
using MarvelRivals.Models.API;
using MarvelRivals.Services.Heroes;

namespace MarvelRivals.Services.Managers
{
    public class HeroesManager
    {
        private readonly IHeroesService _heroesService;
        private readonly IHeroesRepository _heroesRepository;

        public HeroesManager(IHeroesService heroesService, IHeroesRepository heroesRepository)
        {
            _heroesService = heroesService;
            _heroesRepository = heroesRepository;
        }

        public async Task FetchAllHeroesAndSaveToDatabaseAsync()
        {
            try
            {
                List<HeroDto> response = (await _heroesService.FetchAllAsync()).ToList(); // Explicitly convert IEnumerable to List
                if (response == null || !response.Any()) return;

                List<Models.Entities.Hero> heroes = new List<Models.Entities.Hero>();
                for (var i = 0; i < response.Count; i++)
                {
                    var heroDto = response[i];
                    var id = heroDto.Id;
                    var existingHero = await _heroesRepository.GetByIdAsync(id);
                    if (existingHero != null)
                    {
                        continue;
                    }
                    heroes.Add(HeroMapper.ToEntity(heroDto));
                    await _heroesRepository.AddRangeAsync(heroes);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, etc.
                throw new Exception("Error fetching all maps", ex);
            }
        }

    }
}
