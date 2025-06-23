using Newtonsoft.Json;

namespace MarvelRivalsFanSiteDotNet.Models
{
    public class HeroBoardPlayer
    {

        public HeroBoardPlayer()
        {
            Info = new PlayerInfo();
        }
        [JsonProperty("info")]
        public PlayerInfo Info { get; set; }

        [JsonProperty("player_uid")]
        public long PlayerUid { get; set; }

        [JsonProperty("matches")]
        public int Matches { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("assists")]
        public int Assists { get; set; }

        // Nested classes for complex objects
        public class PlayerInfo
        {
            public PlayerInfo()
            {
                RankSeason = new RankSeason();
            }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("cur_head_icon_id")]
            public string CurrentHeadIconId { get; set; }

            [JsonProperty("rank_season")]
            public RankSeason RankSeason { get; set; }

            [JsonProperty("login_os")]
            public int LoginOs { get; set; }
        }

        public class RankSeason
        {
            [JsonProperty("rank_game_id")]
            public int RankGameId { get; set; }

            [JsonProperty("level")]
            public int Level { get; set; }

            [JsonProperty("rank_score")]
            public string RankScore { get; set; }

            // ... other rank_season properties
        }
    }
}