using MarvelRivals.Models.API;
using MarvelRivalsApi.Models.Entities;

namespace MarvelRivals.Mappings
{
    public static class HeroMapper
    {
        public static HeroDto ToDto(Hero hero)
        {
            HeroDto heroDto = new()
            {
                HeroId = hero.HeroId,
                Name = hero.Name,
                RealName = hero.RealName,
                ImageUrl = hero.ImageUrl,
                Role = hero.Role,
                AttackType = hero.AttackType,
                Difficulty = hero.Difficulty,
                Bio = hero.Bio,
                Lore = hero.Lore,
                Team = hero.Team,
                Abilities = hero.Abilities?.Select(MapAbilityToDto).ToList(),
                Costumes = hero.Costumes?.Select(MapCostumeToDto).ToList(),
                Transformations = hero.Transformations?.Select(MapTransformationToDto).ToList(),
            };
            return heroDto;
        }

        public static AbilityDto MapAbilityToDto(Ability a, int index)
        {
            return new AbilityDto
            {
                Id = a.AbilityId,
                Icon = a.Icon,
                Name = a.Name,
                Type = a.Type,
                IsCollab = a.IsCollab,
                Description = a.Description,
                HeroId = a.HeroId ?? 0,
            };
        }

        public static TransformationDto MapTransformationToDto(Transformation t, int index)
        {
            return new TransformationDto
            {
                TransformationId = t.TransformationId,
                Name = t.Name,
                Icon = t.Icon,
                Health = t.Health,
                MovementSpeed = t.MovementSpeed,
            };
        }

        public static CostumeDto MapCostumeToDto(Costume c, int index)
        {
            return new CostumeDto
            {
                CostumeId = c.CostumeId,
                Name = c.Name,
                Icon = c.Icon,
                Quality = c.Quality != null ? new QualityDto
                {
                    Name = c.Quality.Name,
                    Color = c.Quality.Color,
                    Value = c.Quality.Value,
                    Icon = c.Quality.Icon
                } : null,
                Description = c.Description,
                Appearance = c.Appearance,
                HeroId = c.HeroId ?? 0,
            };
        }
        public static Hero ToEntity(HeroDto Dto)
        {
            Hero hero = new()
            {
                HeroId = Dto.HeroId,
                RealName = Dto.RealName,
                ImageUrl = Dto.ImageUrl,
                Role = Dto.Role,
                AttackType = Dto.AttackType,
                Difficulty = Dto.Difficulty,
                Bio = Dto.Bio,
                Lore = Dto.Lore,
                Team = Dto.Team,
                // Map Transformations from HeroDto to Hero
                Costumes = Dto.Costumes != null ? [.. Dto.Costumes.Select(c => MapCostumesToEntities(c))] : [],
                Abilities = Dto.Abilities != null ? [.. Dto.Abilities.Select(a => MapAbilitiesToEntities(a))] : [],
                Transformations = Dto.Transformations != null ? [.. Dto.Transformations.Select(t => MapTransformationsToEntities(t))] : [],
            };

            foreach (var ability in hero.Abilities)
            {
                ability.HeroId = hero.HeroId; // Ensure HeroId is set for each ability
            }
            return hero;
        }

        public static void UpdateEntity(Hero existingHero, HeroDto dto)
        {
            existingHero.Name = dto.Name;
            existingHero.RealName = dto.RealName;
            existingHero.ImageUrl = dto.ImageUrl;
            existingHero.Role = dto.Role;
            existingHero.AttackType = dto.AttackType;
            existingHero.Difficulty = dto.Difficulty;
            existingHero.Bio = dto.Bio;
            existingHero.Lore = dto.Lore;
            existingHero.Team = dto.Team;

            if (dto.Abilities != null)
            {
                existingHero.Abilities = [.. dto.Abilities.Select(MapAbilitiesToEntities)];
                foreach (var ability in existingHero.Abilities)
                {
                    ability.HeroId = existingHero.HeroId; // Ensure HeroId is set for each ability
                }
            }

            if (dto.Transformations != null)
            {
                existingHero.Transformations = [.. dto.Transformations.Select(MapTransformationsToEntities)];
            }

            if (dto.Costumes != null)
            {
                existingHero.Costumes = [.. dto.Costumes.Select(MapCostumesToEntities)];
            }
        }


        public static AdditionalFields MapAdditionalFields(Dictionary<string, string>? additionalFields)
        {
            return additionalFields != null ? new AdditionalFields
            {
                Key = additionalFields.TryGetValue("Key", out string? value) ? value : null,
                Casting = additionalFields.TryGetValue("Casting", out string? castValue) ? castValue : null,
                EnergyCost = additionalFields.TryGetValue("Energy Cost", out string? energyValue) ? energyValue : null,
                SpecialEffect = additionalFields.TryGetValue("Special Effect", out string? effectValue) ? effectValue : null
            } : new AdditionalFields { };
        }

        public static Ability MapAbilitiesToEntities(AbilityDto a)
        {
            return new Ability
            {
                AbilityId = a.Id,
                Icon = a.Icon,
                Name = a.Name,
                Type = a.Type,
                IsCollab = a.IsCollab,
                Description = a.Description,
                AdditionalFields = MapAdditionalFields(a.AdditionalFields)
            };
        }
        public static Transformation MapTransformationsToEntities(TransformationDto t)
        {
            return new Transformation
            {
                TransformationId = t.TransformationId,
                Name = t.Name,
                Icon = t.Icon,
                Health = t.Health,
                MovementSpeed = t.MovementSpeed,
            };

        }
        public static Costume MapCostumesToEntities(CostumeDto c)
        {
            return new Costume
            {
                CostumeId = c.CostumeId,
                Name = c.Name,
                Icon = c.Icon,
                Quality = new Quality
                {
                    Name = c.Quality?.Name,
                    Color = c.Quality?.Color,
                    Value = c.Quality?.Value,
                    Icon = c.Quality?.Icon
                },
                Description = c.Description,
                Appearance = c.Appearance,
            };
        }
    }
}