using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MarvelRivals.Models.Entities
{
    public class GameMap
    {

        [Key]
        public int Id { get; set; }
        public int GameMapId { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? GameMode { get; set; }
        public bool IsCompetitive { get; set; }
        public SubMap? SubMap { get; set; }
        public string? Video { get; set; }
        public List<string>? Images { get; set; }
    }

    public class SubMap
    {
        [Key]
        public int Id { get; set; }
        public int? SubMapId { get; set; }

        public string? Name { get; set; }

        public string? Thumbnail { get; set; }
    }
}
