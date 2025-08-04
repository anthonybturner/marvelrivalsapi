using MarvelRivals.Models.API;
using MarvelRivalsApi.Models.Entities;

namespace MarvelRivals.Mappings
{
    public static class GameMapsMapper
    {
        public static GameMap ToEntity(GameMapDto map)
        {
            return new GameMap
            {
                GameMapId = map.Id,
                Name = map.Name,
                Description = map.Description,
                Location = map.Location,
                FullName = map.FullName,
                GameMode = map.GameMode,
                IsCompetitive = map.IsCompetitive,
                SubMap = map.SubMap != null ? new MarvelRivalsApi.Models.Entities.SubMap
                {
                    SubMapId = map.SubMap.Id,
                    Name = map.SubMap.Name,
                    Thumbnail = map.SubMap.Thumbnail
                } : null,
                Video = map.Video,
                Images = map.Images ?? []
            };
        }

        public static Models.API.GameMapDto ToDto(GameMap map)
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
                Images = map.Images ?? []
            };
        }
    }
}