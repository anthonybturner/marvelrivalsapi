using MarvelRivalsApiAPI.Models;
using MarvelRivalsApiAPI.Services.MarvelRivalsApiAPI.Services;

public interface IMatchHistoryService
{
    public Task<MatchHistoryResponse> FetchFromDBAsync(int playerName, Boolean isFetchingApi);
    public Task<MatchHistoryResponse> FetchFromAPIAsync(int playerGUID);
}