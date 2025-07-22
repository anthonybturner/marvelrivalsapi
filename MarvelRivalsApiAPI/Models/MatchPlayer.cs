using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MarvelRivalsApiAPI.Models
{
    public class MatchPlayer
    {
        [Key]
        public int id { get; set; }

        [JsonPropertyName("player_uid")]
        public int PlayerUid { get; set; }

        public string? PlayerName { get; set; }
        
        [JsonPropertyName("assists")]
        public int Assists { get; set; }

        [JsonPropertyName("kills")]
        public int Kills { get; set; }

        [JsonPropertyName("deaths")]
        public int Deaths { get; set; }

        public int IsWinId { get; set; }

        [JsonPropertyName("is_win")]
        public IsWinInfo? IsWin { get; set; }

        [JsonPropertyName("disconnected")]
        public bool Disconnected { get; set; }

        [JsonPropertyName("camp")]
        public int? Camp { get; set; }

        [JsonPropertyName("score_info")]
        public PlayerScoreInfo? ScoreInfo { get; set; }

        [JsonPropertyName("player_hero")]
        public PlayerHero? PlayerHero { get; set; }

    }

    public class PlayerHero
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("hero_id")]
        public int HeroId { get; set; }

        [JsonPropertyName("hero_name")]
        public string? HeroName { get; set; }

        [JsonPropertyName("hero_type")]
        public string? HeroType { get; set; }

        [JsonPropertyName("kills")]
        public int Kills { get; set; }

        [JsonPropertyName("deaths")]
        public int Deaths { get; set; 
        }

        [JsonPropertyName("assists")]
        public int Assists { get; set; }

        [JsonPropertyName("play_time")]
        public double PlayTimeId { get; set; }

        [JsonPropertyName("total_hero_damage")]
        public double TotalHeroDamage { get; set; }


        [JsonPropertyName("total_damage_taken")]

        public double TotalDamageTaken { get; set; }
        
        [JsonPropertyName("total_hero_heal")]
        public int TotalHeroHeal { get; set; }

    }
    public class PlayerScoreInfo
    {
        [Key]
        public int id { get; set; }

        [JsonPropertyName("add_score")]
        public double? addScore { get; set; }

        [JsonPropertyName("level")]
        public int? level { get; set; }

        [JsonPropertyName("new_level")]
        public int? newLevel { get; set; }

        [JsonPropertyName("new_score")]
        public double? newScore { get; set; }
    }

    public class IsWinInfo
    {
        [Key]
        public int id { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("is_win")]
        public bool IsWin { get; set; }
    }
}