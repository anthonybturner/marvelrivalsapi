using MarvelRivals.Data;
using Microsoft.EntityFrameworkCore;


namespace MarvelRivalsApi.TEST.Controllers
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

    }
}
