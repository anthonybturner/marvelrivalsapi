using MarvelRivalsApiAPI.Controllers;
using MarvelRivalsApiAPI.Data;
using MarvelRivalsApiAPI.Models;
using MarvelRivalsApiAPI.Services.MarvelRivalsApiAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace MarvelRivalsApiAPI.TESTs.Controllers
{
    public class MatchHistoryControllerTest{
        private readonly MatchHistoryController _controller;
        private Moq.Mock<IMatchHistoryService> _mockService;
        private readonly Mock<MarvelRivalsDBContext> _mockDbContext;

        // Existing code...
        public MatchHistoryControllerTest()
        {
            _mockService = new Moq.Mock<IMatchHistoryService>();
            // Set up an in-memory database for the DbContext
            var options = new DbContextOptionsBuilder<MarvelRivalsDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase") // Ensure this line is correct
                .Options;
            _mockDbContext = new Mock<MarvelRivalsDBContext>(options);

            _controller = new MatchHistoryController(
                _mockService.Object, _mockDbContext.Object);
        }

        [Theory]
        [InlineData(1)]
        public async Task GetPlayerHistory_ShouldReturnOkResult_WithMatchHistory(int playerGUID)
        {
            // Arrange
            MatchHistoryResponse matchHistoryResponse = new MatchHistoryResponse
            {
                MatchHistory = new List<MatchHistory>()
                {
                    new MatchHistory
                    {
                        MatchUid = "match1",
                    },
                },
                PlayerGuid = playerGUID
            };

            _mockService.Setup(s => s.FetchFromDBAsync(playerGUID, false)).ReturnsAsync(matchHistoryResponse);

            // Act
            var result = await _controller.GetPlayerHistory(playerGUID);

            // Assert
           var okResult = Assert.IsType<OkObjectResult>(result);
           var response = Assert.IsType<MatchHistoryResponse>(okResult.Value);    
           Assert.Equal(response.PlayerGuid, playerGUID);
        }
    }
}
