using MarvelRivals.Data.Repositories.Maps;
using MarvelRivals.Mappings;
using MarvelRivals.Models.API;
using MarvelRivals.Services.Managers;
using MarvelRivalsApi.Data.Repositories.MatchHistoryRepositories;
using MarvelRivalsApi.Mappings;
using MarvelRivalsApi.Models.API;
using MarvelRivalsApi.Services.Managers;
using Microsoft.AspNetCore.Mvc;

namespace MarvelRivalsApi.Controllers
{
    [ApiController]
    [Route("api/match-history")]
    public class MatchHistoryController(IMatchHistoryRepository matchHistoryRepo, MatchHistoryManager matchHistoryManager) : ControllerBase
    {

        [HttpGet("{playerName}")]

        public async Task<ActionResult<IEnumerable<MatchHistoryDto>>> GetAllMatches(string playerName)
        {

            var playerUid = matchHistoryRepo.GetPlayerUid(playerName);
            if (String.IsNullOrEmpty(playerUid))
            {
                playerUid = await matchHistoryManager.FetchPlayerUid(playerName);

                if (String.IsNullOrEmpty(playerUid))
                {
                    return NotFound();
                }
            }

            var matchesDto = new List<MatchHistoryDto>();
            var matches = await matchHistoryRepo.GetAllAsync(playerUid);
            if (matches == null || !matches.Any())
            {
                await matchHistoryManager.FetchAllMatchesAndSaveToDatabaseAsync(playerUid, playerName);
                matches = await matchHistoryRepo.GetAllAsync(playerUid);
                if (matches == null || !matches.Any())
                {
                    return NotFound();
                }
            }
            matchesDto = matches.Select(match => MatchHistoryMapper.ToDto(match)).ToList();
            return Ok(matchesDto);
        }

        [HttpPost("sync-match-history")]
        public async Task<IActionResult> SyncMatches()
        {
            await matchHistoryManager.SyncMatchHistoryToDatabaseAsync();
            return Ok("Matchess synced.");
        }
    }
}