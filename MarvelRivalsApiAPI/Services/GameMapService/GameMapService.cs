using MarvelRivalsApiAPI.Models;
using System.Text.Json;

namespace MarvelRivalsApiAPI.Services.GameMapService
{
    public class GameMapService : IGameMapService
    {
        private List<GameMap>? maps;
        public void GetAllMaps()
        {

        }

        public async Task<GameMap> GetMapAsync(int mapId)
        {
            if (maps == null)
            {
                maps = await GetMapsAsync();
            }
            return maps?.Find(map => map.MapId == mapId);
        }

        public async Task<List<GameMap>> GetMapsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-api-key", "27fe50d87b5dbebd1ab01589b08a2e00d3c6058a07097c0d6ee47a84e8f4c329");
                client.BaseAddress = new Uri("https://marvelrivalsapi.com/api/v1/");

                HttpResponseMessage response = await client.GetAsync($"maps?limit=42");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonDocument = JsonDocument.Parse(content);
                    var mapsElement = jsonDocument.RootElement.GetProperty("maps");

                    // Deserialize the JSON array to GameMap[]
                   return maps = JsonSerializer.Deserialize<List<GameMap>>(mapsElement.GetRawText());
                }
            }
            return null;
        }
    }
}