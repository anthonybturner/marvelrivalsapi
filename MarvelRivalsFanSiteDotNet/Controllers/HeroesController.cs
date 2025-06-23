using MarvelRivalsFanSiteDotNet.Services;
using MarvelRivalsFanSiteDotNet.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MarvelRivalsFanSiteDotNet.Controllers
{
    public class HeroesController : Controller
    {
        private IHeroesService _heroesService;

        public HeroesController(IHeroesService heroesService) {
            _heroesService = heroesService;
        }   

        // GET: Heroes
        public async Task<ActionResult> Index()
        {
            var response = await _heroesService.GetHeroesAsync();
            return View(response);
        }
    }
}