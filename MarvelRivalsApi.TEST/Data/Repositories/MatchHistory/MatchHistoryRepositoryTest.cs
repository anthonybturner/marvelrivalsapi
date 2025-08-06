using MarvelRivals.Data;
using MarvelRivalsApi.Data.Repositories.MatchHistoryRepositories;
using Microsoft.EntityFrameworkCore;

namespace MarvelRivalsApi.TEST.Data.Repositories.MatchHistory
{
    public class MatchHistoryRepositoryTest
    {

        private DbContextOptions<ApplicationDbContext> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllMatchHistories_ForGivenUid()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var testUid = "player123";
            using (var context = new ApplicationDbContext(options))
            {
                context.MatchHistory.Add(
                    new Models.Entities.MatchHistory
                    {
                        MatchMapName = "Test Map Name",
                        MatchPlayerUid = testUid,
                        MatchPlayer = new Models.Entities.MatchPlayer
                        {
                            PlayerUid = 123,
                            PlayerHero = new Models.Entities.PlayerHero(),
                            ScoreInfo = new Models.Entities.PlayerScoreInfo()
                        }
                    }
                );
                context.SaveChanges();
            }

            // Act
            // Call the GetAllAsync method
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new MatchHistoryRepository(context);
                var result = await repository.GetAllAsync();
                // Assert
                // Verify that the returned list contains all match histories
                Assert.NotNull(result);
                Assert.Single(result.ToList());
                Assert.Equal(testUid, result.First().MatchPlayerUid);
            }
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnMatchHistory_ForGivenId()
        {
            // Arrange
            var options = GetInMemoryOptions();

            var testUid = "player123";
            using (var context = new ApplicationDbContext(options))
            {
                context.MatchHistory.Add(
                    new Models.Entities.MatchHistory
                    {
                        Id = 1,
                        MatchMapName = "Test Map Name",
                        MatchPlayerUid = testUid,
                        MatchPlayer = new Models.Entities.MatchPlayer
                        {
                            PlayerUid = 123,
                            PlayerHero = new Models.Entities.PlayerHero(),
                            ScoreInfo = new Models.Entities.PlayerScoreInfo()
                        }
                    }
                );
                context.SaveChanges();
            }

            // Act
            // Call the GetAllAsync method
            using (var context = new ApplicationDbContext(options))
            {

                var repository = new MatchHistoryRepository(context);
                var result = await repository.GetByIdAsync(1);

                // Assert
                // Verify that the returned list contains all match histories
                Assert.NotNull(result);
                Assert.Equal(1, result.Id);

            }
        }

        [Fact]
        public async Task AddAsync_ShoulAddMatchHistoryToDB_ForGivenMatchHistory()
        {
            // Arrange
            var options = GetInMemoryOptions();


            var testUid = "player123";
            var testNewMatchHistoryUid = "player124";

            var matchHistory = new Models.Entities.MatchHistory
            {
                Id = 2,
                MatchMapName = "Test Map Name 2",
                MatchPlayerUid = testNewMatchHistoryUid,
                MatchPlayer = new Models.Entities.MatchPlayer
                {
                    PlayerUid = 123,
                    PlayerHero = new Models.Entities.PlayerHero(),
                    ScoreInfo = new Models.Entities.PlayerScoreInfo()
                }
            };

            using (var context = new ApplicationDbContext(options))
            {
                context.MatchHistory.Add(
                    new Models.Entities.MatchHistory
                    {
                        Id = 1,
                        MatchMapName = "Test Map Name",
                        MatchPlayerUid = testUid,
                        MatchPlayer = new Models.Entities.MatchPlayer
                        {
                            PlayerUid = 123,
                            PlayerHero = new Models.Entities.PlayerHero(),
                            ScoreInfo = new Models.Entities.PlayerScoreInfo()
                        }
                    }
                );
                context.SaveChanges();
            }

            // Act
            // Call the GetAllAsync method
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new MatchHistoryRepository(context);
                await repository.AddAsync(matchHistory);
                await context.SaveChangesAsync();
                var result = await context.MatchHistory.FirstOrDefaultAsync(matchHistory => matchHistory.Id == 2);

                // Assert
                // Verify that the returned list contains all match histories
                Assert.NotNull(result);
                Assert.Equal(2, result.Id);
                Assert.Equal("Test Map Name 2", result.MatchMapName);
            }
        }

        [Fact]
        public async Task AddRangeAsync_ShoulAddMatchHistoryToDB_ForGivenMatchHistoryList()
        {
            // Arrange
            var options = GetInMemoryOptions();
            var testUid = "player123";
            var testNewMatchHistoryUid = "player124";

            var matchHistory = new List<Models.Entities.MatchHistory>
            {
                new Models.Entities.MatchHistory
                {
                    Id = 2,
                    MatchMapName = "Test Map Name 2",
                    MatchPlayerUid = testNewMatchHistoryUid,
                    MatchPlayer = new Models.Entities.MatchPlayer
                    {
                        PlayerUid = 123,
                        PlayerHero = new Models.Entities.PlayerHero(),
                        ScoreInfo = new Models.Entities.PlayerScoreInfo()
                    }
                },
                new Models.Entities.MatchHistory
                {
                    Id = 3,
                    MatchMapName = "Test Map Name 3",
                    MatchPlayerUid = testNewMatchHistoryUid,
                    MatchPlayer = new Models.Entities.MatchPlayer
                    {
                        PlayerUid = 1234,
                        PlayerHero = new Models.Entities.PlayerHero(),
                        ScoreInfo = new Models.Entities.PlayerScoreInfo()
                    }
                }
            };

            using (var context = new ApplicationDbContext(options))
            {
                context.MatchHistory.Add(
                    new Models.Entities.MatchHistory
                    {
                        Id = 1,
                        MatchMapName = "Test Map Name",
                        MatchPlayerUid = testUid,
                        MatchPlayer = new Models.Entities.MatchPlayer
                        {
                            PlayerUid = 123,
                            PlayerHero = new Models.Entities.PlayerHero(),
                            ScoreInfo = new Models.Entities.PlayerScoreInfo()
                        }
                    }
                );
                context.SaveChanges();
            }

            // Act
            // Call the GetAllAsync method
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new MatchHistoryRepository(context);
                await repository.AddRangeAsync(matchHistory);
                var result = await context.MatchHistory
                    .OrderBy(mh => mh.Id)
                    .ToListAsync();

                // Assert
                // Verify that the returned list contains all match histories
                Assert.NotNull(result);
                Assert.Collection(result,
                    item => Assert.Equal(1, item.Id),
                    item => Assert.Equal(2, item.Id),
                    item => Assert.Equal(3, item.Id)
                );
            }
        }
    }


}
