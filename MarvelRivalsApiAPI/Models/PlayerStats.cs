using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarvelRivalsApiAPI.Models
{
    public class PlayerStats
    {
        [Key]
        public string Uid { get; set; }
        public string Name { get; set; }

        // Store updates and overall_stats as JSON if structure is dynamic
        public string UpdatesJson { get; set; }
        public string OverallStatsJson { get; set; }

        [NotMapped]
        public Dictionary<string, object> Updates
        {
            get => UpdatesJson == null ? null : System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(UpdatesJson);
            set => UpdatesJson = System.Text.Json.JsonSerializer.Serialize(value);
        }

        [NotMapped]
        public Dictionary<string, object> OverallStats
        {
            get => OverallStatsJson == null ? null : System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(OverallStatsJson);
            set => OverallStatsJson = System.Text.Json.JsonSerializer.Serialize(value);
        }

        // Player info
        public string PlayerId { get; set; }
        public string Nickname { get; set; }
        public bool IsPrivate { get; set; }

        // Collections
        public ICollection<PlayerMatchHistoryItem> MatchHistory { get; set; }
        public ICollection<PlayerRankHistoryItem> RankHistory { get; set; }
        public ICollection<PlayerHeroMatchup> HeroMatchups { get; set; }
        public ICollection<PlayerTeammate> TeamMates { get; set; }

        // Store these as JSON for flexibility
        public string HeroesRankedJson { get; set; }
        public string HeroesUnrankedJson { get; set; }
        public string MapsJson { get; set; }

        [NotMapped]
        public Dictionary<string, int> HeroesRanked
        {
            get => HeroesRankedJson == null ? null : System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, int>>(HeroesRankedJson);
            set => HeroesRankedJson = System.Text.Json.JsonSerializer.Serialize(value);
        }

        [NotMapped]
        public Dictionary<string, int> HeroesUnranked
        {
            get => HeroesUnrankedJson == null ? null : System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, int>>(HeroesUnrankedJson);
            set => HeroesUnrankedJson = System.Text.Json.JsonSerializer.Serialize(value);
        }

        [NotMapped]
        public Dictionary<string, int> Maps
        {
            get => MapsJson == null ? null : System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, int>>(MapsJson);
            set => MapsJson = System.Text.Json.JsonSerializer.Serialize(value);
        }
    }

    public class PlayerMatchHistoryItem
    {
        [Key]
        public string MatchId { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
    }

    public class PlayerRankHistoryItem
    {
        [Key]
        public int Id { get; set; }
        public int Season { get; set; }
        public string Rank { get; set; }
        public int Points { get; set; }
    }

    public class PlayerHeroMatchup
    {
        [Key]
        public int Id { get; set; }
        public int HeroId { get; set; }
        public double WinRate { get; set; }
    }

    public class PlayerTeammate
    {
        [Key]
        public string TeammateId { get; set; }
        public string Nickname { get; set; }
    }
}