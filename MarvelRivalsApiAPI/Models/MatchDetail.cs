using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class MatchDetailResponse
{
    [JsonPropertyName("match_details")]
    public MatchDetail MatchDetails { get; set; }
}

public class MatchDetail
{
    [Key]
    public int Id { get; set; }

    [JsonPropertyName("match_uid")]
    public string MatchUid { get; set; }

    [JsonPropertyName("game_mode")]
    public GameMode GameMode { get; set; }

    [JsonPropertyName("replay_id")]
    public string ReplayId { get; set; }

    [JsonPropertyName("mvp_uid")]
    public long MvpUid { get; set; }

    [JsonPropertyName("mvp_hero_id")]
    public int MvpHeroId { get; set; }

    [JsonPropertyName("svp_uid")]
    public long SvpUid { get; set; }

    [JsonPropertyName("svp_hero_id")]
    public int SvpHeroId { get; set; }

    [NotMapped]
    public Dictionary<string, object> DynamicFields { get; set; }

    [JsonPropertyName("match_players")]
    public List<MatchDetailsPlayers> MatchPlayers { get; set; }
}

public class GameMode
{
    [Key]
    public int Id { get; set; }

    [JsonPropertyName("game_mode_id")]
    public int GameModeId { get; set; }

    [JsonPropertyName("game_mode_name")]
    public string GameModeName { get; set; }
}

public class Badge
{
    [Key]
    public int BadgesId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("id")]
    public int BadgeId { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}
