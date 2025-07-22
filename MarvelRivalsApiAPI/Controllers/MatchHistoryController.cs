using MarvelRivalsApiAPI.Data;
using MarvelRivalsApiAPI.Models;
using MarvelRivalsApiAPI.Services.MarvelRivalsApiAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MarvelRivalsApiAPI.Controllers
{
    [ApiController]
    [Route("player")]
    public class MatchHistoryController : Controller
    {
        private readonly IMatchHistoryService _matchHistoryService;
        private readonly MarvelRivalsDBContext _context;

        public MatchHistoryController(IMatchHistoryService matchHistoryService, MarvelRivalsDBContext dbContext) {
            _matchHistoryService = matchHistoryService;
            _context = dbContext;
        }

        // GET: PlayerMatchHistoryController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("{playerGUID}/match-history")]
        public async Task<ActionResult> GetPlayerHistory(int playerGUID)
        {

          MatchHistoryResponse matchHistoryResponse = await _matchHistoryService.FetchFromDBAsync(playerGUID, false);
            if(matchHistoryResponse == null || matchHistoryResponse.MatchHistory == null || !matchHistoryResponse.MatchHistory.Any())
            {
                matchHistoryResponse = await _matchHistoryService.FetchFromAPIAsync(playerGUID);
            }
            // Map DB entities to DTO if needed, or return as is
            return Ok(matchHistoryResponse);
        }
    }
}
