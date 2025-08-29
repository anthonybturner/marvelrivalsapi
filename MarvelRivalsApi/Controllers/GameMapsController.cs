using MarvelRivals.Data.Repositories.Maps;
using MarvelRivals.Mappings;
using MarvelRivals.Models.API;
using MarvelRivals.Services.Managers;
using Microsoft.AspNetCore.Mvc;

namespace MarvelRivals.Controllers
{
    //This controller would respond to HTTP requests like:  
    //- `GET /api/game-maps` to get all maps  
    //- `GET /api/game-maps/5` to get the map with ID 5
    [ApiController]
    [Route("api/game-maps")]
    public class GameMapsController : ControllerBase
    {
        private readonly IGameMapsRepository gameMapsRepo;
        private readonly GameMapsManager gameMapsManager;

        public GameMapsController(IGameMapsRepository gameMapsRepo, GameMapsManager gameMapsManager)
        {
            this.gameMapsRepo = gameMapsRepo;
            this.gameMapsManager = gameMapsManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameMapDto>>> GetAllMaps()
        {
            var maps = await gameMapsRepo.GetAllAsync();
            var mappedGameMaps = maps.Select(GameMapsMapper.ToDto).ToList(); // Assuming GameMapper has a ToDto method
            return Ok(mappedGameMaps);
        }

        [HttpGet("{id}")]
        public IActionResult GetMapById(int id)
        {
            if (id < 0)
            {
                return BadRequest(new
                {
                    type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
                    title = "One or more validation errors occurred.",
                    status = 400,
                    errors = new
                    {
                        Id = new[] { $"The value '{id}' is not valid." }
                    }
                });
            }
            // Logic to get a specific game map by id
            var response = gameMapsRepo.GetByIdAsync(id);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpPost("sync")]
        public async Task<IActionResult> SyncMaps()
        {
            await gameMapsManager.InitAsync();
            return Ok("Maps synced.");
        }
    }
}
