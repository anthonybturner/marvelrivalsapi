namespace MarvelRivalsApiAPI.Services
{
    using global::MarvelRivalsApiAPI.Data;
    using global::MarvelRivalsApiAPI.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;


    namespace MarvelRivalsApiAPI.Services
    {
        public class MatchHistoryResponse
        {
            public string? PlayerName { get; set; }
            public int PlayerGuid { get; set; }
            public List<MatchHistory> MatchHistory { get; set; }
        }

        public class MatchHistoryService : IMatchHistoryService
        {
            private readonly MarvelRivalsDBContext _context;
            private readonly IGameMapService _gameMapsService;

            public MatchHistoryService(MarvelRivalsDBContext context, IGameMapService gameMapsService)
            {
                _context = context;
                _gameMapsService = gameMapsService;
            }
            public async Task<MatchHistoryResponse?> FetchFromAPIAsync(int playerGUID)
            {
                List<MatchHistory> matchHistory = new List<MatchHistory>();
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("x-api-key", "27fe50d87b5dbebd1ab01589b08a2e00d3c6058a07097c0d6ee47a84e8f4c329");
                    client.BaseAddress = new Uri("https://marvelrivalsapi.com/api/v2/player/");

                    HttpResponseMessage httpResponse = await client.GetAsync($"{playerGUID}/match-history");
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        var jsonDocument = System.Text.Json.JsonDocument.Parse(content);
                        var matchHistoryElement = jsonDocument.RootElement.GetProperty("match_history");
                        matchHistory = System.Text.Json.JsonSerializer.Deserialize<List<MatchHistory>>(matchHistoryElement.GetRawText());
                    }
                }

                foreach (MatchHistory match in matchHistory)
                {
                    await CreateMatchInfo(match);
                }

                var response = new MatchHistoryResponse
                {
                    PlayerGuid = playerGUID,
                    MatchHistory = matchHistory
                };
                return response;
            }

            public async Task<MatchHistoryResponse> FetchFromDBAsync(int playerGUID, bool isFetchingApi = false)
            {
                // Try to get match history from the database
                List<MatchHistory> matchHistoryItems = _context.MatchHistory
                    .Include(m => m.MatchPlayer).ThenInclude(mp => mp.PlayerHero)
                    .Include(m => m.ScoreInfo)
                    .Include(m => m.MatchPlayer.IsWin)
                    .Where(m => m.MatchPlayer.PlayerUid == playerGUID)
                    .ToList();

                var response = new MatchHistoryResponse
                {
                    PlayerGuid = playerGUID,
                    MatchHistory = matchHistoryItems
                };

                return response;
            }

            private async Task CreateMapInfo(MatchHistory match)
            {
                match.MapThumbnail = "https://www.marvelrivalsapi.com"; //Assign default place holder thumb if gamemap is null
                match.MatchMapName = "Unknown";

                var gameMap = await _gameMapsService.GetMapAsync(match.MatchMapId);
                if (gameMap != null)
                {
                    match.MapThumbnail = $"{match.MapThumbnail}{gameMap.Images[2]}";
                    match.MatchMapName = $"{gameMap?.Name ?? "Unknown"}";
                }
            }

            public async Task CreateMatchInfo(MatchHistory match)
            {
                // Fetch existing match from the database
                var currentMatch = _context.MatchHistory.FirstOrDefault(m => m.MatchUid == match.MatchUid);

                if (currentMatch != null)
                {
                    // Update existing match
                    currentMatch.MatchMapId = match.MatchMapId;
                    currentMatch.MatchMapName = match.MatchMapName;
                    currentMatch.MapThumbnail = match.MapThumbnail;
                    currentMatch.MatchPlayDuration = match.MatchPlayDuration;
                    currentMatch.MatchSeason = match.MatchSeason;
                    currentMatch.MatchWinnerSide = match.MatchWinnerSide;
                    currentMatch.MvpUid = match.MvpUid;
                    currentMatch.SvpUid = match.SvpUid;
                    currentMatch.ScoreInfo = match.ScoreInfo;
                    currentMatch.MatchTimeStamp = match.MatchTimeStamp;
                    currentMatch.PlayModeId = match.PlayModeId;
                    currentMatch.GameModeId = match.GameModeId;
                    currentMatch.MatchPlayer = match.MatchPlayer;
                }
                else
                {
                    // Add new match if it doesn't exist
                    _context.MatchHistory.Add(match);
                }
                // Save changes to the database
                await _context.SaveChangesAsync();
            }

            private void CreateWinInfo(MatchPlayer matchPlayer)
            {
                if (matchPlayer?.IsWin != null)
                {
                    // Try to find existing IsWinInfo
                    var existingIsWin = _context.IsWinInfo
                        .FirstOrDefault(i => i.id == matchPlayer.IsWinId);

                    if (existingIsWin != null)
                    {
                        existingIsWin.IsWin = matchPlayer.IsWin.IsWin;
                        existingIsWin.Score = matchPlayer.IsWin.Score; // Update score if needed
                    }
                    else
                    {
                        _context.IsWinInfo.Add(matchPlayer.IsWin);
                        // EF will set IsWinId after SaveChanges
                    }
                }
            }

            private void CreateMatchPlayerInfo(MatchPlayer matchPlayer)
            {
                var playerUid = matchPlayer?.PlayerUid;
                if (playerUid != null)
                {
                    // Try to get the tracked or existing MatchPlayer
                    var existingPlayer = _context.MatchPlayer.Local
                        .FirstOrDefault(p => p.PlayerUid == playerUid) ?? _context.MatchPlayer.FirstOrDefault(p => p.PlayerUid == playerUid);

                    if (existingPlayer != null)
                    {
                        existingPlayer = matchPlayer; // Use the tracked/existing entity
                    }
                    else
                    {
                        _context.MatchPlayer.Add(matchPlayer); // Add new if not exists
                    }
                }
            }
        }
    }
}
