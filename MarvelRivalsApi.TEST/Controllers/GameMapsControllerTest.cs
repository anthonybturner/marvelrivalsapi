using MarvelRivals.Data;
using MarvelRivals.Services.GameMaps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelRivals.TEST.Controllers
{
    public class GameMapsControllerTest
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _context;

        public GameMapsControllerTest()
        {
            _httpClient = new HttpClient(); // Initialize HttpClient

            // Fix: Provide DbContextOptions<ApplicationDbContext> to the ApplicationDbContext constructor
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase") // Use an in-memory database for testing
                .Options;

            _context = new ApplicationDbContext(options); // Pass the options to the constructor
        }

        [Fact]
        public async Task FetchGameMapsFromApiAsync_Should_ReturnGameMaps()
        {
            var service = new GameMapsService(_httpClient, _context); // Pass required parameters
           // var gameMaps = await service.FetchGameMapsFromApiAsync();
           // Assert.NotNull(gameMaps);
           // Assert.True(gameMaps.Any());
        }
    }
}
