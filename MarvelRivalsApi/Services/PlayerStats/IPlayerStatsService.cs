using MarvelRivalsApi.Models.API;

namespace MarvelRivalsApi.Services.PlayerStats
{
    public interface IPlayerStatsService
    {
        public Task<PlayerStatDto?> FetchByUidAsync(long uid);

        public Task<PlayerStatDto> SearchAsync(string? name, string? type);
    }
}
