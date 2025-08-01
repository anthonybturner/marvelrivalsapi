using MarvelRivals.Data.Repositories.Maps;
using MarvelRivals.Mappings;
using MarvelRivals.Models.API;
using MarvelRivals.Models.Entities;
using MarvelRivals.Services.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameMapDto>>> GetAllMaps()
        {
            var maps = await _gameMapsRepo.GetAllAsync();
            var mappedGameMaps = maps.Select(GameMapsMapper.ToDto).ToList(); // Assuming GameMapper has a ToDto method
            return Ok(mappedGameMaps);
        }

        [HttpGet("{id}")]
        public IActionResult GetMapById(int id)
        {

            // Logic to get a specific game map by id
            var response = _gameMapsRepo.GetByIdAsync(id);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpPost("sync-maps")]
        public async Task<IActionResult> SyncMaps()
        {
            await _gameMapsManager.InitAsync();
            return Ok("Maps synced.");
        }
    }
}
