using MarvelRivals.Models.API;
using MarvelRivals.Models.Entities;

namespace MarvelRivals.Mappings
{
    public static class GameMapsMapper
    {
        public static Models.Entities.GameMap ToEntity(GameMapDto map)
        {
            return new Models.Entities.GameMap
            {
                GameMapId = map.Id,
                Name = map.Name,
                Description = map.Description,
                Location = map.Location,
                FullName = map.FullName,
                GameMode = map.GameMode,
                IsCompetitive = map.IsCompetitive,
                SubMap = map.SubMap != null ? new Models.Entities.SubMap
                {
                    SubMapId = map.SubMap.Id,
                    Name = map.SubMap.Name,
                    Thumbnail = map.SubMap.Thumbnail
                } : null,
                Video = map.Video,
                Images = map.Images ?? new List<string>()
            };
        }

        public static Models.API.GameMapDto ToDto(Models.Entities.GameMap map)
        {
            return new Models.API.GameMapDto
            {
                Id = map.Id,
                Name = map.Name,
                Description = map.Description,
                Location = map.Location,
                FullName = map.FullName,
                GameMode = map.GameMode,
                IsCompetitive = map.IsCompetitive,
                SubMap = map.SubMap != null ? new Models.API.SubMap
                {
                    Id = map.SubMap.Id,
                    Name = map.SubMap.Name,
                    Thumbnail = map.SubMap.Thumbnail
                } : null,
                Video = map.Video,
                Images = map.Images ?? new List<string>()
            };
        }
    }
}