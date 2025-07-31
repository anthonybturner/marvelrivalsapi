using MarvelRivals.Models.API;
using MarvelRivals.Models.Entities;

namespace MarvelRivals.Mappings
{
    public static class HeroMapper
    {
        public static Hero ToEntity(HeroDto Dto)
        {
            return new Hero
            {
                Id = Dto.Id,
                RealName = Dto.RealName,
                ImageUrl = Dto.ImageUrl,
                Role = Dto.Role,
                AttackType = Dto.AttackType,
                Difficulty = Dto.Difficulty,
                Bio = Dto.Bio,
                Lore = Dto.Lore,
                // Map Transformations from HeroDto to Hero
                Transformations = TransformationsToEntities(Dto),
                Costumes = CostumesToEntities(Dto),
                Abilities = AbilitiesToEntities(Dto),
            };
        }

        public static HeroDto ToDto(Hero hero)
        {
            return new HeroDto
            {
                Id = hero.Id,
                RealName = hero.RealName,
                ImageUrl = hero.ImageUrl,
                Role = hero.Role,
                AttackType = hero.AttackType,
                Difficulty = hero.Difficulty,
                Bio = hero.Bio,
                Lore = hero.Lore,
            };
        }



        public static List<Transformation>? TransformationsToEntities(HeroDto hero)
        {
            return hero.Transformations != null ? [.. hero.Transformations.Select(t => new Transformation
            {
                TransformationsId = t.Id,
                Name = t.Name,
                Icon = t.Icon,
                Health = t.Health,
                MovementSpeed = t.MovementSpeed,
                HeroId = hero.Id
            })] : [];
        }

        public static List<Ability> AbilitiesToEntities(HeroDto hero)
        {
            List<Ability> abilities = [];
            if (hero.Abilities != null)
            {
                // Only add abilities that do not already exist
                abilities = [.. hero.Abilities
                    .Select(a => new Ability
                    {
                        AbilityId = a.Id,
                        Icon = a.Icon,
                        Name = a.Name,
                        Type = a.Type,
                        IsCollab = a.IsCollab,
                        Description = a.Description,
                        HeroId = hero.Id,
                    })];
            }
            return abilities;
        }

        public static List<Costume> CostumesToEntities(HeroDto hero)
        {
            return hero.Costumes != null ? [.. hero.Costumes.Select(c => new Costume
            {
                CostumeId = c.Id,
                Name = c.Name,
                Icon = c.Icon,
                Quality = c.Quality,
                Description = c.Description,
                Appearance = c.Appearance,
                HeroId = hero.Id

            })] : [];
        }

    }

}
