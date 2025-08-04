namespace MarvelRivalsApi.Models.Entities
{
    public class PlayerScoreInfo
    {
        public int Id { get; set; } // Primary key
        public double? AddScore { get; set; }
        public int? Level { get; set; }
        public int? NewLevel { get; set; }
        public double? NewScore { get; set; }
    }
}
