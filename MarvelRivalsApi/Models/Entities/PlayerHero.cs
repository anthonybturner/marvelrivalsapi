namespace MarvelRivalsApi.Models.Entities
{
    public class PlayerHero
    {
        public int Id { get; set; } // Primary key
        public int? HeroId { get; set; }
        public string? HeroName { get; set; } = string.Empty;
        public string? HeroType { get; set; } = string.Empty;
        public int? Kills { get; set; }
        public int? Deaths { get; set; }
        public int? Assists { get; set; }
        public double? PlayTime { get; set; }
        public double? TotalHeroDamage { get; set; }
        public double? TotalDamageTaken { get; set; }
        public double? TotalHeroHeal { get; set; }
    }
}
