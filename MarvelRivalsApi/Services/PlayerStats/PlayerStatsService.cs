using MarvelRivalsApi.Models.API;
using System.Text.Json;

namespace MarvelRivalsApi.Services.PlayerStats
{
    public class PlayerStatsService : IPlayerStatsService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public PlayerStatsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("x-api-key", "27fe50d87b5dbebd1ab01589b08a2e00d3c6058a07097c0d6ee47a84e8f4c329");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "PlayerStatsServiceClient");

            // Initialize JsonSerializerOptions once
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }
        public async Task<PlayerStatDto> FetchByUidAsync(long uid)
        {
            var response = await _httpClient.GetAsync($"v1/player/{uid}");
            response.EnsureSuccessStatusCode(); // Throw an exception if the response status is not 2xx

            // Deserialize the JSON response into a list of HeroDto
            var content = await response.Content.ReadAsStringAsync();
            var playerStats = JsonSerializer.Deserialize<PlayerStatDto>(content, _jsonSerializerOptions);
            return playerStats ?? new PlayerStatDto();
        }
        public Task<PlayerStatDto> SearchAsync(string? name, string? type)
        {
            throw new NotImplementedException();
        }
    }
}      