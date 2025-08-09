using MarvelRivals.Data;
using MarvelRivalsApi.Data.Repositories.Matchhistory;
using Microsoft.EntityFrameworkCore;

namespace MarvelRivalsApi.TEST.Data.Repositories.MatchHistory
{
    public class MatchHistoryRepositoryTest
    {

        private static DbContextOptions<ApplicationDbContext> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        private static List<Models.Entities.MatchHistory> GetMockMatchHistoryList()
        {
            var playerName = "Test Player";
            var matchHistory = CreateMockMatchHistory("1", "test map name", 123, playerName);
            var matchHistory2 = CreateMockMatchHistory("2", "test map name 2", 456, playerName);
            var matchHistory3 = CreateMockMatchHistory("3", "test map name 3", 789, playerName);

            return [matchHistory, matchHistory2, matchHistory3];

        }


        private static Models.Entities.MatchHistory CreateMockMatchHistory(string matchUid, string matchMapName, long playerUid, string playerName)
        {
            var matchHistory = new Models.Entities.MatchHistory
            {
                MatchUid = matchUid,
                MatchMapName = matchMapName,
                MatchPlayer = new Models.Entities.MatchPlayer
                {
                    PlayerUid = playerUid,
                    PlayerName = playerName,
                    PlayerHero = new Models.Entities.PlayerHero(),
                    ScoreInfo = new Models.Entities.PlayerScoreInfo(),
                    MatchHistory = new Models.Entities.MatchHistory()
                }
            };
            matchHistory.MatchPlayer.MatchHistory = matchHistory;
            return matchHistory;
        }
        private static void AddNewMatchHistoryToDatabase(DbContextOptions<ApplicationDbContext> options, string matchUid, string mapName, long playerUid, string playerName)
        {
            var matchHistory = CreateMockMatchHistory(matchUid, mapName, playerUid, playerName);
            SaveMatchHistory(options, matchHistory);
        }

        private static void SaveMatchHistory(DbContextOptions<ApplicationDbContext> options, Models.Entities.MatchHistory matchHistory)
        {
            using var context = new ApplicationDbContext(options);
            context.MatchHistory.Add(matchHistory);
            context.SaveChanges();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllMatchHistories_ForGivenUid()
        {
            // Arrange
            var options = GetInMemoryOptions();
            var matchUid = "1";
            var playerUid = 123;
            AddNewMatchHistoryToDatabase(options, matchUid, "test map name", playerUid, "Test Player");

            // Act
            // Call the GetAllAsync method
            using var context = new ApplicationDbContext(options);
            var repository = new MatchHistoryRepository(context);
            var result = await repository.GetAllAsync(playerUid);
            // Assert
            // Verify that the returned list contains all match histories
            Assert.NotNull(result?.First().MatchPlayer);
            Assert.Single(result.ToList());
            Assert.Equal(matchUid, result.First().MatchUid);
            Assert.Equal(playerUid, result?.First()?.MatchPlayer?.PlayerUid);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnMatchHistory_ForGivenId()
        {
            // Arrange
            var options = GetInMemoryOptions();
            var matchUid = "1";
            AddNewMatchHistoryToDatabase(options, matchUid, "test map name", 123, "Test Player");
            // Act
            // Call the GetAllAsync method
            using var context = new ApplicationDbContext(options);
            var repository = new MatchHistoryRepository(context);
            var result = await repository.GetByIdAsync(matchUid);

            // Assert
            // Verify that the returned list contains all match histories
            Assert.NotNull(result);
            Assert.Equal(matchUid, result.MatchUid);
        }


        [Fact]
        public async Task AddAsync_ShouldSaveMatchHistory_ForGivenMatchHistory()
        {
            // Arrange
            var options = GetInMemoryOptions();
            var matchUid = "1";

            // Act
            // Call the GetAllAsync method
            using (var context = new ApplicationDbContext(options))
            {
                var matchHistory = CreateMockMatchHistory(matchUid, "Test Map Name 2", 123, "Test Player");
                var repository = new MatchHistoryRepository(context);
                await repository.AddAsync(matchHistory);
                await context.SaveChangesAsync();
                var result = await context.MatchHistory.FirstOrDefaultAsync(matchHistory => matchHistory.MatchUid == matchUid);

                // Assert
                // Verify that the returned list contains all match histories
                Assert.NotNull(result);
                Assert.Equal(matchUid, result.MatchUid);
                Assert.Equal("Test Map Name 2", result.MatchMapName);
            }
        }
        [Fact]
        public async Task GetPlayerUidAsync_ShouldReturnPlayerUid_ForGivenPlayerName()
        {
            // Arrange
            var options = GetInMemoryOptions();
            var matchUid = "1";
            var playerName = "Test Player";
            var playerUid = 123;

            AddNewMatchHistoryToDatabase(options, matchUid, "Test Map Name 1", playerUid, playerName);

            // Act
            // Call the GetAllAsync method
            using var context = new ApplicationDbContext(options);
            var repository = new MatchHistoryRepository(context);
            long? resultPlayerUid = await repository.GetPlayerUidAsync(playerName);

            // Assert
            // Verify that the returned list contains all match histories
            Assert.NotNull(resultPlayerUid);
            Assert.Equal(playerUid, resultPlayerUid);
        }


        [Fact]
        public async Task AddRangeAsync_ShouldAddMatchHistoryListToDB()
        {
            // Arrange
            var options = GetInMemoryOptions();
            List<Models.Entities.MatchHistory> matchHistories = GetMockMatchHistoryList();

            // Act
            // Call the GetAllAsync method
            using var context = new ApplicationDbContext(options);
            var repository = new MatchHistoryRepository(context);
            await repository.AddRangeAsync(matchHistories);
            var result = await context.MatchHistory.OrderBy(mh => mh.MatchUid)
                .ToListAsync();

            // Assert
            // Verify that the returned list contains all match histories
            Assert.NotNull(result);
            Assert.Collection(result,
             item => Assert.Equal("1", item.MatchUid),
             item => Assert.Equal("2", item.MatchUid),
             item => Assert.Equal("3", item.MatchUid)
             );
        }

        [Fact]
        public async Task HasMatchHistory_ShouldReturnTrue_ForTheGivenMatchId()
        {
            // Arrange
            var options = GetInMemoryOptions();
            var matchUid = "1";
            var playerName = "Test Player";
            var playerUid = 123;

            AddNewMatchHistoryToDatabase(options, matchUid, "Test Map Name 1", playerUid, playerName);

            // Act
            // Call the GetAllAsync method
            using var context = new ApplicationDbContext(options);
            var repository = new MatchHistoryRepository(context);
            bool hasMatch = await repository.HasMatchHistoryAsync(matchUid);

            // Assert
            // Verify that the returned list contains all match histories
            Assert.True(hasMatch);
        }

        [Fact]
        public async Task GetPlayersUidsAsync_ShouldReturnPlayersUids()
        {
            // Arrange
            var options = GetInMemoryOptions();
            var matchUid = "1";
            var playerName = "Test Player";
            var playerUid = 123;

            AddNewMatchHistoryToDatabase(options, matchUid, "Test Map Name 1", playerUid, playerName);
            AddNewMatchHistoryToDatabase(options, "2", "Test Map Name 2", 456, "Test Player 2");
            // Act
            // Call the GetAllAsync method
            using var context = new ApplicationDbContext(options);
            var repository = new MatchHistoryRepository(context);
            var playersUids = await repository.GetPlayersUidsAsync();
            playersUids = playersUids?.OrderBy(p => p).ToList();
            // Assert
            // Verify that the returned list contains all match histories
            Assert.NotNull(playersUids);
            Assert.Collection(playersUids,
                item => Assert.Equal(123, item),
                item => Assert.Equal(456, item)
            );
        }

        [Fact]
        public async Task GetPlayersInfoAsync_ShouldReturnPlayerInfos()
        {
            // Arrange
            var options = GetInMemoryOptions();
            var matchUid = "1";
            var matchUid2 = "2";
            var playerName = "Test Player";
            var playerName2 = "Test Player2";

            var playerUid = 123;
            var playerUid2 = 456;

            AddNewMatchHistoryToDatabase(options, matchUid, "Test Map Name 1", playerUid, playerName);
            AddNewMatchHistoryToDatabase(options, matchUid2, "Test Map Name 1", playerUid2, playerName2);

            // Act
            // Call the GetAllAsync method
            using var context = new ApplicationDbContext(options);
            var repository = new MatchHistoryRepository(context);
            var playerInfoDto = await repository.GetPlayersInfoAsync();

            // Assert
            Assert.NotNull(playerInfoDto);
            Assert.Equal(2, playerInfoDto.Count);

            Assert.Contains(playerInfoDto, p => p.PlayerName == playerName && p.PlayerUid == playerUid);
            Assert.Contains(playerInfoDto, p => p.PlayerName == playerName2 && p.PlayerUid == playerUid2);

        }

        [Fact]
        public static async Task DeleteAsync_ShoulDeleteMatchHistory_ForGivenMatchHistoryId()
        {
            // Arrange
            var options = GetInMemoryOptions();
            var matchUid = "1";

            AddNewMatchHistoryToDatabase(options, matchUid, "Test Map Name", 123, "Test Player");
            // Act
            // Call the GetAllAsync method
            using var context = new ApplicationDbContext(options);
            var repository = new MatchHistoryRepository(context);
            await repository.DeleteAsync(matchUid);
            await context.SaveChangesAsync();

            var result = await context.MatchHistory.FirstOrDefaultAsync(matchHistory => matchHistory.MatchUid == matchUid);

            // Assert
            // Verify that the returned list contains all match histories
            Assert.Null(result);
            Assert.Equal(0, await context.MatchHistory.CountAsync());
        }
    }
}