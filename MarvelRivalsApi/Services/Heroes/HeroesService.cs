using MarvelRivals.Data;
using MarvelRivals.Models.API;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace MarvelRivals.Services.Heroes
{
    public class HeroesService : IHeroesService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public HeroesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("x-api-key", "27fe50d87b5dbebd1ab01589b08a2e00d3c6058a07097c0d6ee47a84e8f4c329");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "HeroesServiceClient");

            // Initialize JsonSerializerOptions once
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }

        private async Task<IEnumerable<HeroDto>> FetchAllAsync()
        {
            var response = await _httpClient.GetAsync("v2/heroes");
            response.EnsureSuccessStatusCode(); // Throw an exception if the response status is not 2xx

            // Deserialize the JSON response into a list of HeroDto
            var content = await response.Content.ReadAsStringAsync();
            var heroes = JsonSerializer.Deserialize<IEnumerable<HeroDto>>(content, _jsonSerializerOptions);
            return heroes ?? [];
        }

        public Task<HeroDto?> FetchByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HeroDto>> FetchByTypeAsync(string type)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HeroDto>> SearchAsync(string? name, string? type)
        {
            throw new NotImplementedException();
        }
    

        Task<HeroDto?> IHeroesService.FetchByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<HeroDto>> IHeroesService.FetchAllAsync()
        {
            return FetchAllAsync();
        }

        Task<IEnumerable<HeroDto>> IHeroesService.FetchByTypeAsync(string type)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<HeroDto>> IHeroesService.SearchAsync(string? name, string? type)
        {
            throw new NotImplementedException();
        }
    }
}      