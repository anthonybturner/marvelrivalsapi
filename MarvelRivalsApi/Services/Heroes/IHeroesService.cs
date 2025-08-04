using MarvelRivals.Models.API;

namespace MarvelRivals.Services.Heroes
{
    public interface IHeroesService
    {
        public Task<HeroDto?> FetchByIdAsync(int id);
        public Task<IEnumerable<HeroDto>> FetchAllAsync();

        public Task<IEnumerable<HeroDto>> FetchByTypeAsync(string type);
        public Task<IEnumerable<HeroDto>> SearchAsync(string? name, string? type);
    }
}
