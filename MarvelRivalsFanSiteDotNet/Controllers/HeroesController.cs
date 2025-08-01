using MarvelRivalsFanSiteDotNet.Services;
using MarvelRivalsFanSiteDotNet.Services.Interfaces;
using System.Threading.Tasks;
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
        [Route("heroes")]
        public async Task<ActionResult> Index()
        {
            var response = await _heroesService.GetHeroesAsync();
            return View(response);
        }
    }
}