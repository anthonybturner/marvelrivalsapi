using MarvelRivals.Data;
using MarvelRivals.Models.API;
using MarvelRivalsApi.Models.API;
using MarvelRivalsApi.Services.MatchHistoryService;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;

namespace MarvelRivalsApi.Services.MatchHistory
{
    public class MatchHistoryService : IMatchHistoryService
    {

        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _context;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        public MatchHistoryService(HttpClient httpClient, ApplicationDbContext context)
        {
            _httpClient = httpClient;
            _context = context;
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("x-api-key", "27fe50d87b5dbebd1ab01589b08a2e00d3c6058a07097c0d6ee47a84e8f4c329");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "MatchHistoryServiceClient");

            // Initialize JsonSerializerOptions once
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

        }

        public async Task<MatchHistoryResponseDto> FetchAllAsync(long playerUid, string playerName)
        {
            var response = await _httpClient.GetAsync($"v2/player/{playerUid}/match-history");
            response.EnsureSuccessStatusCode(); // Throw an exception if the response status is not 2xx

            // Deserialize the JSON response into a list of MatchHistoryDto
            var content = await response.Content.ReadAsStringAsync();
            var matchHistoryResponse = JsonSerializer.Deserialize<MatchHistoryResponseDto>(content, _jsonSerializerOptions);

            // Ensure matchHistoryResponse and its MatchHistory property are not null
            if (matchHistoryResponse?.MatchHistory != null)
            {
                foreach (var match in matchHistoryResponse.MatchHistory)
                {
                    match.MatchPlayer.PlayerUid = playerUid;
                    match.MatchPlayer.PlayerName = playerName;
                }
            }

            return matchHistoryResponse ?? new MatchHistoryResponseDto { MatchHistory = [] };
        }

        public async Task<FindPlayerResponse?> FetchPlayerUid(string playerName)
        {
            var response = await _httpClient.GetAsync($"v1/find-player/{playerName}");
            response.EnsureSuccessStatusCode(); // Throw an exception if the response status is not 2xx

            var content = await response.Content.ReadAsStringAsync();
            var playerResponse = JsonSerializer.Deserialize<FindPlayerResponse>(content, _jsonSerializerOptions);
            if (playerResponse?.PlayerUid == null)
            {
                throw new Exception($"PlayerUid not found for player: {playerName}");
            }

            return playerResponse;
        }
    }
}