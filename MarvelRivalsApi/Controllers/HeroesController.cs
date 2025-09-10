using MarvelRivals.Data.Repositories.Heroes;
using MarvelRivals.Mappings;
using MarvelRivals.Models.API;
using MarvelRivals.Services.Managers;
using MarvelRivalsApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MarvelRivals.Controllers
{
    [ApiController]
    [Route("api/heroes")]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroesRepository heroesRepository;
        private readonly HeroesManager heroesManager;

        public HeroesController(IHeroesRepository heroesRepository, HeroesManager heroesManager)
        {
            this.heroesRepository = heroesRepository;
            this.heroesManager = heroesManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeroDto>>> GetAllHeroes()
        {
            var heroes = await heroesRepository.GetAllAsync();
            var response = heroes.Select(hero => HeroMapper.ToDto(hero)); // Explicitly specify the type argument
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Hero>> GetHero(int id)
        {
                    
            var response = await heroesRepository.GetByIdAsync(id);
            if (response == null) { return NotFound(); }
            return Ok(response);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Hero>> GetHeroByName(string name)
        {

            var response = await heroesRepository.GetByNameAsync(name);
            if (response == null) { return NotFound(); }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Hero>>> AddHero([FromBody] HeroDto Dto)
        {
            Hero hero = HeroMapper.ToEntity(Dto);
            await heroesRepository.AddAsync(hero);
            await heroesRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHero), new { hero.Id }, hero);
        }

        [HttpPost("sync")]
        public async Task<IActionResult> SyncHeroes()
        {
            await heroesManager.InitAsync();
            return Ok("Heroes synced.");
        }
    }
}
