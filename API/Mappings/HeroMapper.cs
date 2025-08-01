using MarvelRivals.Models.API;
using MarvelRivals.Models.Entities;

namespace MarvelRivals.Mappings
{
    public static class HeroMapper
    {

        #region EntityToDTO
        public static HeroDto ToDto(Hero hero)
        {
            return new HeroDto
            {
                Id = hero.Id,
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
                Description = a.Description
            };
        }

        public static TransformationDto MapTransformationToDto(Transformation t, int index)
        {
            return new TransformationDto
            {
                Id = t.TransformationsId,
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
                Id = c.CostumeId,
                Name = c.Name,
                Icon = c.Icon,
                Quality = c.Quality,
                Description = c.Description,
                Appearance = c.Appearance,
            };
        }
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
                Team = Dto.Team,
                // Map Transformations from HeroDto to Hero
                Costumes = Dto.Costumes != null ? [.. Dto.Costumes.Select(c => MapCostumesToEntities(c))] : [],
                Abilities = Dto.Abilities != null ? [.. Dto.Abilities.Select(a => MapAbilitiesToEntities(a))] : [],
                Transformations = Dto.Transformations != null ? [.. Dto.Transformations.Select(t => MapTransformationsToEntities(t))] : [],
            };
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
                TransformationsId = t.Id,
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
                CostumeId = c.Id,
                Name = c.Name,
                Icon = c.Icon,
                Quality = c.Quality,
                Description = c.Description,
                Appearance = c.Appearance,
            };
        }

        #endregion
    }
}