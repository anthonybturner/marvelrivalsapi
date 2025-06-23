using MarvelRivalsFanSiteDotNet.Services;
using MarvelRivalsFanSiteDotNet.Services.Interfaces;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MarvelRivalsFanSiteDotNet.Views
{
    public class LeaderBoardController : Controller
    {
        private ILeaderboardService _leaderboardService;

        public LeaderBoardController(ILeaderboardService leaderboardService) {
            _leaderboardService = leaderboardService;  
        }

        [HttpGet]
        public async Task<ActionResult> Index(string heroName, string sortBy = "rank", bool ascending = false)
        {
            if (string.IsNullOrEmpty(heroName))
            {
                heroName = "spider-man";
            }
            var response = await _leaderboardService.GetHeroBoardPlayersAsync(heroName, sortBy, ascending);
            ViewBag.HeroName = heroName;
            ViewBag.SortBy = sortBy;
            ViewBag.Ascending = ascending;

            return View(response.Players);
        }
    }
}