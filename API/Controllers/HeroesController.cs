using MarvelRivals.Data.Repositories.Heroes;
using MarvelRivals.Mappings;
using MarvelRivals.Models.API;
using MarvelRivals.Models.Entities;
using MarvelRivals.Services.Managers;
using Microsoft.AspNetCore.Mvc;

namespace MarvelRivals.Controllers
{
    [ApiController]
    [Route("api/heroes")]
    public class HeroesController(IHeroesRepository heroesRepository, HeroesManager heroesManager) : ControllerBase
    {
        private readonly IHeroesRepository _heroesRepository = heroesRepository;
        private readonly HeroesManager _heroesManager = heroesManager;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeroDto>>> GetAllHeroes()
        {
            // Fix: Await the Task returned by GetAllAsync and then convert the result to a list
            var heroes = (await _heroesRepository.GetAllAsync());
            var response = heroes.Select(HeroMapper.ToDto); // Assuming HeroMapper has a ToDto method
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHero(string id)
        {
            if (String.IsNullOrEmpty(id)){
                return BadRequest(new{
                    type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
                    title = "One or more validation errors occurred.",
                    status = 400,
                    errors = new
                    {
                        Id = new[] { $"The value '{id}' is not valid." }
                    }
                });
            }

            var response = await _heroesRepository.GetByIdAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<Hero>>> AddHero([FromBody] HeroDto Dto)
        {
            Hero hero = HeroMapper.ToEntity(Dto);
            await _heroesRepository.AddAsync(hero);
            await _heroesRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHero), new { hero.Id }, hero);
        }


        [HttpPost("sync-heroes")]
        public async Task<IActionResult> SyncHeroes()
        {
            await _heroesManager.InitAsync();
            return Ok("Heroes synced.");
        }
    }
}
