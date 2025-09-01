using MarvelRivals.Data.Repositories.Heroes;
using MarvelRivalsApi.Data.Repositories.PlayerStats;
using MarvelRivalsApi.Models.API;
using MarvelRivalsApi.Models.Entities;
using MarvelRivalsApi.Services.Managers;
using Microsoft.AspNetCore.Mvc;

namespace MarvelRivalsApi.Controllers
{
    [ApiController]
    [Route("api/player")]
    public class PlayerStatsController : ControllerBase
    {

        private readonly IPlayerStatsRepository pStatsRepository;
        private readonly PlayerStatsManager pStatsManager;

        public PlayerStatsController(IPlayerStatsRepository repo, PlayerStatsManager manger)
        {
            this.pStatsRepository = repo;
            this.pStatsManager = manger;
        }

        [HttpGet("{uid}")]
        public async Task<ActionResult<PlayerStatDto>> GetStat(long uid)
        {
            var response = await pStatsRepository.GetByUIdAsync(uid);
            if (response == null) {
                await pStatsManager.FetchPlayerStatsAndSaveToDatabaseAsync(uid);
                response = await pStatsRepository.GetByUIdAsync(uid);
           }
            return Ok(response);
        }
    }
}
