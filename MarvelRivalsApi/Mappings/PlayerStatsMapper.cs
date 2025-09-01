using MarvelRivals.Models.API;
using MarvelRivalsApi.Models.API;
using MarvelRivalsApi.Models.Entities;

namespace MarvelRivalsApi.Mappings
{
    public class PlayerStatsMapper
    {
        public static PlayerStatDto EntityToDto(PlayerStat pStatEntity)
        {
            PlayerStatDto dto = new()
            {
                Uid = pStatEntity.Uid,
                Name = pStatEntity.Name,
                Updates = pStatEntity.Updates != null ? new PlayerUpdatesDto
                {
                    InfoUpdateTime = pStatEntity.Updates.InfoUpdateTime,
                    LastHistoryUpdate = pStatEntity.Updates.LastHistoryUpdate,
                    LastInsertedMatch = pStatEntity.Updates.LastInsertedMatch,
                    LastUpdateRequest = pStatEntity.Updates.LastUpdateRequest,
                } : new PlayerUpdatesDto(),

                Player = pStatEntity.Player != null ? new PlayerDto
                {
                    Uid = pStatEntity.Player.Uid,
                    level = pStatEntity.Player.level,
                    Name = pStatEntity.Player.Name,
                    Icon = pStatEntity.Player.Icon != null ? new PlayerIconDto
                    {
                        Icon = pStatEntity.Player.Icon.Icon,
                        IconId = pStatEntity.Player.Icon.IconId,
                    } : new PlayerIconDto(),
                    Rank = pStatEntity.Player.Rank != null ? new PlayerRankDto
                    {
                        Color = pStatEntity.Player.Rank.Color,
                        Image = pStatEntity.Player.Rank.Image,
                        Rank = pStatEntity.Player.Rank.Rank,
                    } : new PlayerRankDto(),
                    Team = pStatEntity.Player.Team != null ? new PlayerTeamDto
                    {
                        ClubTeamId = pStatEntity.Player.Team.ClubTeamId,
                        ClubTeamMiniName = pStatEntity.Player.Team.ClubTeamMiniName,
                        ClubTeamType = pStatEntity.Player.Team.ClubTeamType,

                    } : new PlayerTeamDto(),
                    Info = pStatEntity.Player.Info != null ? new PlayerInfoDto
                    {
                        PlayerUid = pStatEntity.Player.Info.PlayerUid,
                        PlayerName = pStatEntity.Player.Info.PlayerName,
                    } : new PlayerInfoDto(),
                } : new PlayerDto(),

                OverallStats = pStatEntity.OverallStats != null ? new PlayerOverallStatsDto
                {
                    TotalMatches = pStatEntity.OverallStats.TotalMatches,
                    TotalWins = pStatEntity.OverallStats.TotalWins,
                    Unranked = pStatEntity.OverallStats.Unranked != null ? new PlayerUnrankedDto
                    {
                        TotalMatches = pStatEntity.OverallStats.Unranked.TotalMatches,
                        TotalWins = pStatEntity.OverallStats.Unranked.TotalWins,
                        TotalAssists = pStatEntity.OverallStats.Unranked.TotalAssists,
                        TotalDeaths = pStatEntity.OverallStats.Unranked.TotalDeaths,
                        TotalKills = pStatEntity.OverallStats.Unranked.TotalKills,
                        TotalTimePlayed = pStatEntity.OverallStats.Unranked.TotalTimePlayed,
                        TotalTimePlayedRaw = pStatEntity.OverallStats.Unranked.TotalTimePlayedRaw,
                        TotalMvp = pStatEntity.OverallStats.Unranked.TotalMvp,
                        TotalSvp = pStatEntity.OverallStats.Unranked.TotalSvp,
                    } : new PlayerUnrankedDto(),
                    Ranked = pStatEntity.OverallStats.Ranked != null ? new PlayerRankedDto
                    {
                        TotalMatches = pStatEntity.OverallStats.Ranked.TotalMatches,
                        TotalWins = pStatEntity.OverallStats.Ranked.TotalWins,
                        TotalAssists = pStatEntity.OverallStats.Ranked.TotalAssists,
                        TotalDeaths = pStatEntity.OverallStats.Ranked.TotalDeaths,
                        TotalKills = pStatEntity.OverallStats.Ranked.TotalKills,
                        TotalTimePlayed = pStatEntity.OverallStats.Ranked.TotalTimePlayed,
                        TotalTimePlayedRaw = pStatEntity.OverallStats.Ranked.TotalTimePlayedRaw,
                        TotalMvp = pStatEntity.OverallStats.Ranked.TotalMvp,
                        TotalSvp = pStatEntity.OverallStats.Ranked.TotalSvp,
                    }
                   : new PlayerRankedDto(),
                } : new PlayerOverallStatsDto(),

            };
            return dto;
        }

        public static PlayerStat DtoToEntity(PlayerStatDto pStatDto)
        {
            // PSEUDOCODE (as comments):
            // 1. If input dto null -> return null.
            // 2. Map scalar properties (Uid, Name if present).
            // 3. For Updates: if dto.Updates != null create PlayerUpdates and copy fields.
            // 4. For Player: if dto.Player != null create Player and nested:
            //    - Icon, Rank, Team, Info each only if their dto counterparts not null.
            // 5. For OverallStats: if dto.OverallStats != null map totals and nested Ranked / Unranked.
            // 6. Ignore FK Ids (EF will set when saving if using relationships).
            // 7. Return fully built PlayerStat entity.
            if (pStatDto == null) return null;

            var entity = new PlayerStat
            {
                Uid = pStatDto.Uid,
                // Name property mapped only if DTO actually contains it in real model (omitted here due to snippet inconsistency)
                Updates = pStatDto.Updates != null ? new PlayerUpdates
                {
                    InfoUpdateTime = pStatDto.Updates.InfoUpdateTime,
                    LastHistoryUpdate = pStatDto.Updates.LastHistoryUpdate,
                    LastInsertedMatch = pStatDto.Updates.LastInsertedMatch,
                    LastUpdateRequest = pStatDto.Updates.LastUpdateRequest
                } : null,
                Player = pStatDto.Player != null ? new Player
                {
                    Uid = pStatDto.Player.Uid,
                    level = pStatDto.Player.level,
                    Name = pStatDto.Player.Name,
                    Icon = pStatDto.Player.Icon != null ? new PlayerIcon
                    {
                        Icon = pStatDto.Player.Icon.Icon,
                        IconId = pStatDto.Player.Icon.IconId
                    } : null,
                    Rank = pStatDto.Player.Rank != null ? new PlayerRank
                    {
                        Color = pStatDto.Player.Rank.Color,
                        Image = pStatDto.Player.Rank.Image,
                        Rank = pStatDto.Player.Rank.Rank
                    } : null,
                    Team = pStatDto.Player.Team != null ? new PlayerTeam
                    {
                        ClubTeamId = pStatDto.Player.Team.ClubTeamId,
                        ClubTeamMiniName = pStatDto.Player.Team.ClubTeamMiniName,
                        ClubTeamType = pStatDto.Player.Team.ClubTeamType
                    } : null,
                    Info = pStatDto.Player.Info != null ? new PlayerStatsPlayerInfo
                    {
                        PlayerUid = pStatDto.Player.Info.PlayerUid,
                        PlayerName = pStatDto.Player.Info.PlayerName
                    } : null
                } : null,
                OverallStats = pStatDto.OverallStats != null ? new PlayerOverallStats
                {
                    TotalMatches = pStatDto.OverallStats.TotalMatches,
                    TotalWins = pStatDto.OverallStats.TotalWins,
                    Unranked = pStatDto.OverallStats.Unranked != null ? new PlayerUnranked
                    {
                        TotalMatches = pStatDto.OverallStats.Unranked.TotalMatches,
                        TotalWins = pStatDto.OverallStats.Unranked.TotalWins,
                        TotalAssists = pStatDto.OverallStats.Unranked.TotalAssists,
                        TotalDeaths = pStatDto.OverallStats.Unranked.TotalDeaths,
                        TotalKills = pStatDto.OverallStats.Unranked.TotalKills,
                        TotalTimePlayed = pStatDto.OverallStats.Unranked.TotalTimePlayed,
                        TotalTimePlayedRaw = pStatDto.OverallStats.Unranked.TotalTimePlayedRaw,
                        TotalMvp = pStatDto.OverallStats.Unranked.TotalMvp,
                        TotalSvp = pStatDto.OverallStats.Unranked.TotalSvp
                    } : null,
                    Ranked = pStatDto.OverallStats.Ranked != null ? new PlayerRanked
                    {
                        TotalMatches = pStatDto.OverallStats.Ranked.TotalMatches,
                        TotalWins = pStatDto.OverallStats.Ranked.TotalWins,
                        TotalAssists = pStatDto.OverallStats.Ranked.TotalAssists,
                        TotalDeaths = pStatDto.OverallStats.Ranked.TotalDeaths,
                        TotalKills = pStatDto.OverallStats.Ranked.TotalKills,
                        TotalTimePlayed = pStatDto.OverallStats.Ranked.TotalTimePlayed,
                        TotalTimePlayedRaw = pStatDto.OverallStats.Ranked.TotalTimePlayedRaw,
                        TotalMvp = pStatDto.OverallStats.Ranked.TotalMvp,
                        TotalSvp = pStatDto.OverallStats.Ranked.TotalSvp
                    } : null
                } : null
            };

            return entity;
        }
    }
}
