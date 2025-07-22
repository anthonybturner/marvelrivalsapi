using MarvelRivalsApiAPI.Models;
using MarvelRivalsApiAPI.Services.MarvelRivalsApiAPI.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelRivalsApiAPI.TESTs.Services.MatchHistoryService
{
    public class MatchHistoryServiceTest
    {
        public MatchHistoryServiceTest()
        {
        }

        [Fact]
        public async Task FetchFromAPIAsync_Should_Return_MatchHistory_ForValidPlayerGUID()
        {
            // Arrange
            var playerGuid = 123;
            var response = new MatchHistoryResponse
            {
                PlayerGuid = playerGuid,
                MatchHistory = new List<MatchHistory> {
                    new MatchHistory { MatchUid = "test_match_uid" },
                    new MatchHistory { MatchUid = "test_match_uid_2" },
                }
            };
            
            var _mockService = new Mock<IMatchHistoryService>();
            _mockService.Setup(s => s.FetchFromAPIAsync(playerGuid)).ReturnsAsync(response);

            // Act
            var result = await _mockService.Object.FetchFromAPIAsync(playerGuid);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.MatchHistory.Count);
            Assert.Equal("test_match_uid", result.MatchHistory[0].MatchUid);
        }

        [Fact]
        public async Task FetchFromDBAsync_Should_Return_MatchHistory_ForValidPlayerGUID()
        {
            // Arrange
            var playerGuid = 123;
            var expectedMatchHistory = new MatchHistoryResponse()
            {
                PlayerGuid = playerGuid,
                MatchHistory = new List<MatchHistory>
               {
                    new MatchHistory { MatchUid = "test_match_uid" },
                    new MatchHistory { MatchUid = "test_match_uid_2" },
               }
            };
            var _mockService = new Mock<IMatchHistoryService>();
            _mockService.Setup(s => s.FetchFromDBAsync(playerGuid, false)).ReturnsAsync(expectedMatchHistory); ;

            // Act
            var result = await _mockService.Object.FetchFromDBAsync(playerGuid, false);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.MatchHistory.Count);
            Assert.Equal("test_match_uid", result.MatchHistory[0].MatchUid);
        }
    }
}
