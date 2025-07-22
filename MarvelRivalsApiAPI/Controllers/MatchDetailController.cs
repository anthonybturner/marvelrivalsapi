using MarvelRivalsApiAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MarvelRivalsApiAPI.Controllers
{
    [ApiController]
    [Route("match")]
    public class MatchDetailsController : Controller
    {
        private readonly IMatchDetailService _matchDetailService;
        private readonly MarvelRivalsDBContext _context;

        public MatchDetailsController(IMatchDetailService matchDetailService, MarvelRivalsDBContext dbContext)
        {
            _matchDetailService = matchDetailService;
            _context = dbContext;
        }

        // GET: PlayerMatchHistoryController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("{matchUID}")]
        public async Task<ActionResult> GetAsync(string matchUID)
        {

            var matchHistoryItems = await _matchDetailService.GetFromDBAsync(matchUID);

            // Map DB entities to DTO if needed, or return as is
            return Ok(matchHistoryItems);
        }
    }
}
