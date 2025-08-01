using System.Collections.Generic;
using System.Text.Json.Serialization;

public class ApiMatchDetailsResponse
{
    [JsonPropertyName("match_details")]
    public MatchDetails MatchDetails { get; set; }
}

public class MatchDetails
{
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

    [JsonPropertyName("dynamic_fields")]
    public Dictionary<string, object> DynamicFields { get; set; }

    [JsonPropertyName("match_players")]
    public List<MatchPlayer> MatchPlayers { get; set; }
}

public class GameMode
{
    [JsonPropertyName("game_mode_id")]
    public int GameModeId { get; set; }

    [JsonPropertyName("game_mode_name")]
    public string GameModeName { get; set; }
}

public class MatchPlayer
{
    [JsonPropertyName("player_uid")]
    public long PlayerUid { get; set; }

    [JsonPropertyName("nick_name")]
    public string NickName { get; set; }

    [JsonPropertyName("player_icon")]
    public long PlayerIcon { get; set; }

    [JsonPropertyName("camp")]
    public int Camp { get; set; }

    [JsonPropertyName("cur_hero_id")]
    public int CurHeroId { get; set; }

    [JsonPropertyName("cur_hero_icon")]
    public string CurHeroIcon { get; set; }

    [JsonPropertyName("is_win")]
    public int IsWin { get; set; }

    [JsonPropertyName("kills")]
    public int Kills { get; set; }

    [JsonPropertyName("deaths")]
    public int Deaths { get; set; }

    [JsonPropertyName("assists")]
    public int Assists { get; set; }

    [JsonPropertyName("total_hero_damage")]
    public double TotalHeroDamage { get; set; }

    [JsonPropertyName("total_hero_heal")]
    public double TotalHeroHeal { get; set; }

    [JsonPropertyName("total_damage_taken")]
    public double TotalDamageTaken { get; set; }

    [JsonPropertyName("badges")]
    public List<Badge> Badges { get; set; }

    [JsonPropertyName("player_heroes")]
    public List<PlayerHero> PlayerHeroes { get; set; }
}

public class Badge
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}

public class PlayerHero
{
    [JsonPropertyName("hero_id")]
    public int HeroId { get; set; }

    [JsonPropertyName("play_time")]
    public double PlayTime { get; set; }

    [JsonPropertyName("kills")]
    public int Kills { get; set; }

    [JsonPropertyName("deaths")]
    public int Deaths { get; set; }

    [JsonPropertyName("assists")]
    public int Assists { get; set; }

    [JsonPropertyName("session_hit_rate")]
    public double SessionHitRate { get; set; }

    [JsonPropertyName("hero_icon")]
    public string HeroIcon { get; set; }
}