using MarvelRivals.Data;
using MarvelRivals.Models.API;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace MarvelRivals.Services.GameMaps
{
    public class GameMapsService : IGameMapsService
    {

        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _context;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public GameMapsService(HttpClient httpClient, ApplicationDbContext context)
        {
            _httpClient = httpClient;
            _context = context;
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("x-api-key", "27fe50d87b5dbebd1ab01589b08a2e00d3c6058a07097c0d6ee47a84e8f4c329");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "HeroesServiceClient");

            // Initialize JsonSerializerOptions once
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

        }

        public async Task<GameMapResponseDto> FetchAllAsync()
        {
            var response = await _httpClient.GetAsync("v1/maps?limit=42");
            response.EnsureSuccessStatusCode(); // Throw an exception if the response status is not 2xx

            // Deserialize the JSON response into a list of HeroDto
            var content = await response.Content.ReadAsStringAsync();
            var maps = JsonSerializer.Deserialize<GameMapResponseDto>(content, _jsonSerializerOptions);
            return maps;
        }

        public async Task<GameMapDto> FetchByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"v2/map/{id}");
            response.EnsureSuccessStatusCode(); // Throw an exception if the response status is not 2xx

            // Deserialize the JSON response into a list of HeroDto
            var content = await response.Content.ReadAsStringAsync();
            var maps = JsonSerializer.Deserialize<GameMapDto>(content, _jsonSerializerOptions);
            return maps;
        }
    }
}
