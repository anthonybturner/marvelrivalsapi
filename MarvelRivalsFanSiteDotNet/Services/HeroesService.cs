using MarvelRivalsFanSiteDotNet.Models;
using MarvelRivalsFanSiteDotNet.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MarvelRivalsFanSiteDotNet.Services
{
    public class HeroesService : IHeroesService
    {
        private readonly HttpClient _httpClient;

        public HeroesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HeroesResponse> GetHeroesAsync()
        {
            var url = "heroes";
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<HeroesResponse>(content);
                return result;
            }
            catch (HttpRequestException e)
            {
                throw new ApplicationException($"Error fetching heroes: {e.Message}");
            }
        }

    }

}