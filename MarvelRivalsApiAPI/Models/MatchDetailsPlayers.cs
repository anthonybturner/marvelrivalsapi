using MarvelRivalsApiAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class MatchDetailsPlayers
{
    [Key]
    public int Id { get; set; }

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

    public MatchDetailsPlayers()
    {
        Badges = new List<Badge>();
        PlayerHeroes = new List<PlayerHero>();
    }
}