
using MarvelRivalsApi.Data.Repositories.MatchHistory;
using MarvelRivalsApi.Mappings;
using MarvelRivalsApi.Models.API;
using MarvelRivalsApi.Services.Managers;
using Microsoft.AspNetCore.Mvc;

namespace MarvelRivalsApi.Controllers
{
    [ApiController]
    [Route("api/match-history")]
    public class MatchHistoryController : ControllerBase
    {
        private readonly IMatchHistoryRepository matchHistoryRepo;
        private readonly MatchHistoryManager matchHistoryManager;

        public MatchHistoryController(IMatchHistoryRepository matchHistoryRepo, MatchHistoryManager matchHistoryManager)
        {
            this.matchHistoryRepo = matchHistoryRepo;
            this.matchHistoryManager = matchHistoryManager;
        }

        [HttpGet("{playerName}")]

        public async Task<ActionResult<IEnumerable<MatchHistoryDto>>> GetAllMatches(string playerName)
        {
            long playerUid = await matchHistoryManager.GetPlayerUid(playerName);
            var matches = await (matchHistoryRepo.GetAllAsync(playerUid));
            if (matches == null || !matches.Any())
            {
                await matchHistoryManager.FetchAllMatchesAndSaveToDatabaseAsync(playerUid, playerName);
                matches = await matchHistoryRepo.GetAllAsync(playerUid);
                if (matches == null || !matches.Any())
                {
                    return NotFound();
                }
            }
            var matchesDto = matches.Select(match => MatchHistoryMapper.ToDto(match)).ToList();
            return Ok(matchesDto);
        }

        [HttpPost("sync-match-history")]
        public async Task<IActionResult> SyncMatches()
        {
            await matchHistoryManager.SyncMatchHistoryToDatabaseAsync();
            return Ok("Matches synced.");
        }
    }
}