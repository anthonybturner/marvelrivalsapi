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
    public class HeroesController : ControllerBase
    {
        private readonly IHeroesRepository _heroesRepository;
        private readonly HeroesManager _heroesManager;

        public HeroesController(IHeroesRepository heroesRepository, HeroesManager heroesManager)
        {
            _heroesRepository = heroesRepository;
            _heroesManager = heroesManager;
            _heroesManager.FetchAllHeroesAndSaveToDatabaseAsync().GetAwaiter().GetResult(); // Ensure heroes are loaded on startup
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hero>>> GetAllHeroes()
        {
            var response = await _heroesRepository.GetAllAsync();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHero(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest(new
                {
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
            return CreatedAtAction(nameof(GetHero), new { Id = hero.Id }, hero);
        }
    }
}
