using MarvelRivals.Models.API;

namespace MarvelRivals.Services.GameMaps
{
    public interface IGameMapsService
    {
        public Task<GameMapDto> FetchAllAsync();
        public Task<GameMapDto> FetchByIdAsync(int id);

    }
}
