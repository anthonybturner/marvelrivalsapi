using MarvelRivals.Models.API;
using MarvelRivalsApi.Models.API;
using MarvelRivalsApi.Models.Entities;

namespace MarvelRivalsApi.Mappings
{
    public class MatchHistoryMapper
    {

        public static MatchHistoryDto ToDto(MatchHistory match)
        {
            return new MatchHistoryDto
            {   Id = match.Id,
                MatchUid = match.MatchUid ?? string.Empty,
                MatchMapId = match.MatchMapId,
                MatchMapName = match.MatchMapName ?? string.Empty,
                MapThumbnail = match.MapThumbnail ?? string.Empty,
                MatchPlayDuration = match.MatchPlayDuration,
                MatchSeason = match.MatchSeason ?? string.Empty,
                MatchWinnerSide = match.MatchWinnerSide,
                MvpUid = match.MvpUid,
                SvpUid = match.SvpUid,
                ScoreInfo = CreateMatchHistoryScoreInfoDto(match),
                MatchTimeStamp = match.MatchTimeStamp,
                PlayModeId = match.PlayModeId,
                GameModeId = match.GameModeId,
                MatchPlayer = CreateMatchPlayerDto(match),
            };
        }

        private static MatchPlayerDto CreateMatchPlayerDto(MatchHistory match)
        {
            return match.MatchPlayer != null ? new MatchPlayerDto
            {
                Assists = match.MatchPlayer.Assists,
                Kills = match.MatchPlayer.Kills,
                Deaths = match.MatchPlayer.Deaths,
                IsWin = match.MatchPlayer.IsWin != null ? new WinInfoDto
                {
                    Score = match.MatchPlayer.IsWin.Score,
                    IsWin = match.MatchPlayer.IsWin.IsWin
                } : new WinInfoDto(),
                Disconnected = match.MatchPlayer.Disconnected,
                PlayerUid = match.MatchPlayer.PlayerUid,
                PlayerName = match.MatchPlayer.PlayerName ?? string.Empty,
                Camp = match.MatchPlayer.Camp,
                ScoreInfo = match.MatchPlayer.ScoreInfo != null ? new PlayerScoreInfoDto
                {
                    AddScore = match.MatchPlayer.ScoreInfo.AddScore,
                    Level = match.MatchPlayer.ScoreInfo.Level,
                    NewLevel = match.MatchPlayer.ScoreInfo.NewLevel,
                    NewScore = match.MatchPlayer.ScoreInfo.NewScore
                } : new PlayerScoreInfoDto(),
                PlayerHero = match.MatchPlayer.PlayerHero != null ? new PlayerHeroDto
                {
                    Id = match.MatchPlayer.PlayerHero.Id,
                    HeroId = match.MatchPlayer.PlayerHero.HeroId,
                    HeroName = match.MatchPlayer.PlayerHero.HeroName ?? string.Empty,
                    HeroType = match.MatchPlayer.PlayerHero.HeroType ?? string.Empty,
                    Kills = match.MatchPlayer.PlayerHero.Kills,
                    Deaths = match.MatchPlayer.PlayerHero.Deaths,
                    Assists = match.MatchPlayer.PlayerHero.Assists,
                    PlayTime = match.MatchPlayer.PlayerHero.PlayTime ?? 0.0,
                    TotalHeroDamage = match.MatchPlayer.PlayerHero.TotalHeroDamage,
                    TotalDamageTaken = match.MatchPlayer.PlayerHero.TotalDamageTaken,
                    TotalHeroHeal = match.MatchPlayer.PlayerHero.TotalHeroHeal
                } : new PlayerHeroDto()
            } : new MatchPlayerDto();
        }

        private static Dictionary<string, int> CreateMatchHistoryScoreInfoDto(MatchHistory match)
        {
            return match.ScoreInfo != null
                                ? new Dictionary<string, int>
                                {
                        { "0", match.ScoreInfo.Zero },
                        { "1", match.ScoreInfo.One }
                                }
                                : [];
        }

        public static MatchHistory ToEntity(MatchHistoryDto match)
        {
            return new MatchHistory
            {
                MatchMapId = match.MatchMapId,
                MatchMapName = match.MatchMapName ?? string.Empty,
                MapThumbnail = match.MapThumbnail ?? string.Empty,
                MatchPlayDuration = match.MatchPlayDuration,
                MatchSeason = match.MatchSeason ?? string.Empty,
                MatchUid = match.MatchUid ?? string.Empty,
                MatchWinnerSide = match.MatchWinnerSide,
                MvpUid = match.MvpUid,
                SvpUid = match.SvpUid,
                ScoreInfo = CreateMatchScoreInfoEntity(match),
                MatchTimeStamp = match.MatchTimeStamp,
                PlayModeId = match.PlayModeId,
                GameModeId = match.GameModeId,
                MatchPlayer = CreateMatchPlayerEntity(match),
            };
        }

        private static Models.Entities.ScoreInfo? CreateMatchScoreInfoEntity(MatchHistoryDto match)
        {
            if (match.ScoreInfo != null && match.ScoreInfo.TryGetValue("0", out int zeroVal) && match.ScoreInfo.TryGetValue("1", out int oneValue))
            {
                return new Models.Entities.ScoreInfo
                {
                    Zero = zeroVal,
                    One = oneValue
                };
            }
            return null;
        }

        private static MatchPlayer? CreateMatchPlayerEntity(MatchHistoryDto match)
        {
            return match.MatchPlayer != null ? new MatchPlayer
            {
                Assists = match.MatchPlayer.Assists,
                Kills = match.MatchPlayer.Kills,
                Deaths = match.MatchPlayer.Deaths,
                IsWin = CreateMatchPlayerIsWinEntity(match),
                Disconnected = match.MatchPlayer.Disconnected,
                PlayerUid = match.MatchPlayer.PlayerUid,
                PlayerName = match.MatchPlayer.PlayerName ?? string.Empty,
                Camp = match.MatchPlayer.Camp,
                ScoreInfo = CreatePlayerScoreInfoEntity(match),
                PlayerHero = CreatePlayerHeroEntity(match),
                MatchHistory = new MatchHistory
                {
                    MatchUid = match.MatchUid ?? string.Empty,
                    MatchMapId = match.MatchMapId,
                    MatchMapName = match.MatchMapName ?? string.Empty,
                    MapThumbnail = match.MapThumbnail ?? string.Empty,
                    MatchPlayDuration = match.MatchPlayDuration,
                    MatchSeason = match.MatchSeason ?? string.Empty,
                    MatchWinnerSide = match.MatchWinnerSide,
                    MvpUid = match.MvpUid,
                    SvpUid = match.SvpUid,
                    ScoreInfo = CreateMatchScoreInfoEntity(match),
                    MatchTimeStamp = match.MatchTimeStamp,
                    PlayModeId = match.PlayModeId,
                    GameModeId = match.GameModeId
                }
            } : null;
        }

        private static WinInfo CreateMatchPlayerIsWinEntity(MatchHistoryDto match)
        {
            return match.MatchPlayer.IsWin != null ? new WinInfo
            {
                Score = match.MatchPlayer.IsWin.Score,
                IsWin = match.MatchPlayer.IsWin.IsWin
            } : new WinInfo();
        }

        private static PlayerScoreInfo CreatePlayerScoreInfoEntity(MatchHistoryDto match)
        {
            return match.MatchPlayer.ScoreInfo != null ? new PlayerScoreInfo
            {
                AddScore = match.MatchPlayer.ScoreInfo.AddScore,
                Level = match.MatchPlayer.ScoreInfo.Level,
                NewLevel = match.MatchPlayer.ScoreInfo.NewLevel,
                NewScore = match.MatchPlayer.ScoreInfo.NewScore
            } : new PlayerScoreInfo();
        }

        private static PlayerHero CreatePlayerHeroEntity(MatchHistoryDto match)
        {
            return match.MatchPlayer.PlayerHero != null ? new PlayerHero
            {
                Id = match.MatchPlayer.PlayerHero.Id,
                HeroId = match.MatchPlayer.PlayerHero.HeroId,
                HeroName = match.MatchPlayer.PlayerHero.HeroName ?? string.Empty,
                HeroType = match.MatchPlayer.PlayerHero.HeroType ?? string.Empty,
                Kills = match.MatchPlayer.PlayerHero.Kills,
                Deaths = match.MatchPlayer.PlayerHero.Deaths,
                Assists = match.MatchPlayer.PlayerHero.Assists,
                PlayTime = match.MatchPlayer.PlayerHero.PlayTime ?? 0.0,
                TotalHeroDamage = match.MatchPlayer.PlayerHero.TotalHeroDamage,
                TotalDamageTaken = match.MatchPlayer.PlayerHero.TotalDamageTaken,
                TotalHeroHeal = match.MatchPlayer.PlayerHero.TotalHeroHeal
            } : new PlayerHero();
        }
    }
}