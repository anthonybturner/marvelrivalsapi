using MarvelRivals.Data.Repositories.Maps;
using MarvelRivals.Models.Entities;
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
        private readonly IGameMapsRepository _gameMapsRepo;
        private readonly GameMapsManager _gameMapsManager;
        public GameMapsController(IGameMapsRepository gameMapsRepo, GameMapsManager gameMapsManager)
        {
            _gameMapsRepo = gameMapsRepo;
            _gameMapsManager = gameMapsManager;
            _gameMapsManager.FetchAllMapsAndSaveToDatabaseAsync().GetAwaiter().GetResult(); // Initialize maps on startup
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameMap>>> GetAllMaps()
        {
            var response = await _gameMapsRepo.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetMapById(int id)
        {
            // Logic to get a specific game map by id
            var response = _gameMapsRepo.GetByIdAsync(id);
            if (response == null) return NotFound();
            return Ok(response);
        }
    }
}
