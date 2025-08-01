using MarvelRivals.Data.Repositories.Heroes;
using MarvelRivals.Mappings;
using MarvelRivals.Models.API;
using MarvelRivals.Services.Heroes;
using Microsoft.EntityFrameworkCore;

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

        public async Task InitAsync()
        {
            await FetchAllHeroesAndSaveToDatabaseAsync();
        }

        public async Task FetchAllHeroesAndSaveToDatabaseAsync()
        {
            try
            {
                var heroDtos = await _heroesService.FetchAllAsync();
                var ids = heroDtos.Select(h => h.Id).Where(id => id != null).Cast<string>().ToList(); // Ensure null values are filtered out and cast to non-nullable
                var existingHeroes = await _heroesRepository.GetByIdsAsync(ids);

                foreach (var dto in heroDtos)
                {
                    var existingHero = existingHeroes.FirstOrDefault(h => h.Id == dto.Id);
                    if (existingHero != null)
                    {
                        HeroMapper.UpdateEntity(existingHero, dto); // Just modifies tracked entity
                    }
                    else
                    {
                        await _heroesRepository.AddAsync(HeroMapper.ToEntity(dto)); // Add new
                    }
                }

                await _heroesRepository.SaveChangesAsync(); // Only one DB hit
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, etc.
                throw new Exception("Error fetching all maps", ex);
            }
        }

    }
}
