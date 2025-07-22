using MarvelRivalsApiAPI.Data;
using MarvelRivalsApiAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarvelRivalsApiAPI.Services.MatchDetailService
{
    public class MatchDetailService : IMatchDetailService
    {

        private readonly MarvelRivalsDBContext _context;



        public MatchDetailService(MarvelRivalsDBContext context)
        {
            _context = context;

        }
        
        Task<global::MatchDetailResponse> IMatchDetailService.GetFromAPIAsync(string matchUid)
        {
            throw new NotImplementedException();
        }
        public async Task<MatchDetail> GetFromDBAsync(string matchUid)
        {
            // Try to get match history from the database
            return await _context.MatchDetail
                .Include(m => m.MatchPlayers)
                .FirstOrDefaultAsync(i => i.MatchUid == matchUid);
        }

        public async Task<MatchDetailResponse> GetFromAPIAsync(string matchUid)
        {
            MatchDetail? matchDetail = null;

            var matchDetailDto = await FetchMatchDetailsAPIAsync(matchUid);
            if (matchDetailDto != null)
            {
                // Map MatchDetailsDto to MatchDetails
                matchDetail = new MatchDetail
                {
                    MatchUid = matchDetailDto.MatchUid,
                    GameMode = new GameMode
                    {
                        GameModeName = matchDetailDto.GameMode.GameModeName
                    },
                    ReplayId = matchDetailDto.ReplayId,
                    MvpUid = matchDetailDto.MvpUid,
                    MvpHeroId = matchDetailDto.MvpHeroId,
                    SvpUid = matchDetailDto.SvpUid,
                    SvpHeroId = matchDetailDto.SvpHeroId,
                    DynamicFields = matchDetailDto.DynamicFields,
                    MatchPlayers = matchDetailDto.MatchPlayers?.Select(mp => new MatchDetailsPlayers
                    {
                        PlayerUid = mp.PlayerUid,
                        NickName = mp.NickName,
                        PlayerIcon = mp.PlayerIcon,
                        Camp = mp.Camp,
                        CurHeroId = mp.CurHeroId,
                        CurHeroIcon = mp.CurHeroIcon ?? String.Empty,
                        IsWin = mp.IsWin,
                        Kills = mp.Kills,
                        Deaths = mp.Deaths,
                        Assists = mp.Assists,
                        TotalHeroDamage = mp.TotalHeroDamage,
                        TotalHeroHeal = mp.TotalHeroHeal,
                        TotalDamageTaken = mp.TotalDamageTaken,
                        Badges = mp.Badges?.Select(b => new Badge
                        {
                            Count = b.Count,
                            Name = b.Name,

                        }).ToList() ?? new List<Badge>(),
                        PlayerHeroes = mp.PlayerHeroes?.Select(ph => new PlayerHero
                        {
                            // Map player hero properties here
                        }).ToList() ?? new List<PlayerHero>()
                    }).ToList() ?? new List<MatchDetailsPlayers>()
                };
                _context.MatchDetail.Add(matchDetail);
                _context.SaveChanges();
            }

            var response = new MatchDetailResponse
            {
                MatchDetails = matchDetail ?? new MatchDetail(), // Ensure MatchDetail is not null
            };

            return response;
        }

        public async Task<MatchDetailsDto?> FetchMatchDetailsAPIAsync(string matchUid)
        {
            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("x-api-key", "27fe50d87b5dbebd1ab01589b08a2e00d3c6058a07097c0d6ee47a84e8f4c329");

                client.BaseAddress = new Uri("https://marvelrivalsapi.com/api/v1/");

                HttpResponseMessage response = await client.GetAsync($"match/{matchUid}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonDocument = System.Text.Json.JsonDocument.Parse(content);
                    var matchDetailElement = jsonDocument.RootElement.GetProperty("match_details");
                    return System.Text.Json.JsonSerializer.Deserialize<MatchDetailsDto>(matchDetailElement.GetRawText());
                }
            }
            return null;
        }

    }
}
