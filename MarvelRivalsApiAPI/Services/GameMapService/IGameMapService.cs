using MarvelRivalsApiAPI.Models;

public interface IGameMapService
{
    public Task<GameMap> GetMapAsync(int mapId);
    public Task<List<GameMap>> GetMapsAsync();
}
