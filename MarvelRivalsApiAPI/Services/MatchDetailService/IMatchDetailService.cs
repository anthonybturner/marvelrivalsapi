using MarvelRivalsApiAPI.Services.MarvelRivalsApiAPI.Services;
using MarvelRivalsApiAPI.Services.MatchDetailService;
using static MarvelRivalsApiAPI.Services.MatchDetailService.MatchDetailService;

public interface IMatchDetailService
{
    Task<MatchDetailResponse> GetFromAPIAsync(string matchUid);
    Task<MatchDetail> GetFromDBAsync(string matchUid);

    Task<MatchDetailsDto?> FetchMatchDetailsAPIAsync(string matchUid);
}