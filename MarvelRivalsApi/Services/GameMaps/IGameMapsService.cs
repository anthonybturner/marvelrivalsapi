using MarvelRivals.Models.API;

namespace MarvelRivals.Services.GameMaps
{
    public interface IGameMapsService
    {
        public Task<GameMapResponseDto> FetchAllAsync();
        public Task<GameMapDto> FetchByIdAsync(int id);

    }
}
