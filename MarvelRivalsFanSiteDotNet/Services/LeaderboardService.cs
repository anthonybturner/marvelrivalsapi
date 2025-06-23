using MarvelRivalsFanSiteDotNet.Models;
using MarvelRivalsFanSiteDotNet.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MarvelRivalsFanSiteDotNet.Services
{
    public class LeaderboardService : ILeaderboardService
    {
        private readonly HttpClient _httpClient;

        public LeaderboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Fix for CS0106 and CS0539: Corrected method signature to match the interface and removed invalid modifier
        public async Task<HeroBoardResponse> GetHeroBoardPlayersAsync(string heroName, string sortBy = "rank", bool ascending = false)
        {
            var url = $"heroes/leaderboard/{heroName}";
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<HeroBoardResponse>(content);
                result.Players = SortPlayers(result.Players, sortBy, ascending);
                return result;
            }
            catch (HttpRequestException e)
            {
                throw new ApplicationException($"Error fetching leaderboard players: {e.Message}");
            }
        }

        private List<HeroBoardPlayer> SortPlayers(List<HeroBoardPlayer> players, string sortBy, bool ascending)
        {
            sortBy = sortBy.ToLower();
            if (sortBy == "kills")
            {
                return ascending ?
                    players.OrderBy(p => p.Kills).ToList() :
                    players.OrderByDescending(p => p.Kills).ToList();
            }
            else if (sortBy == "wins")
            {
                return ascending ?
                    players.OrderBy(p => p.Wins).ToList() :
                    players.OrderByDescending(p => p.Wins).ToList();
            }
            else if (sortBy == "winrate")
            {
                return ascending ?
                    players.OrderBy(p => p.Wins / (double)p.Matches).ToList() :
                    players.OrderByDescending(p => p.Wins / (double)p.Matches).ToList();
            }
            else // Default: sort by rank
            {
                return ascending ?
                    players.OrderBy(p => p.Info.RankSeason?.Level ?? 0).ToList() :
                    players.OrderByDescending(p => p.Info.RankSeason?.Level ?? 0).ToList();
            }
        }

        public async Task<HeroBoardResponse> GetHeroBoardPlayers(int id)
        {
            throw new NotImplementedException();
        }
    }
}