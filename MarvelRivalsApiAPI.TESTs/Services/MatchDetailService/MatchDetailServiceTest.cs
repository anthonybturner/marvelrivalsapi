using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelRivalsApiAPI.TESTs.Services.MatchDetailService
{
    public class MatchDetailServiceTest
    {
        [Fact]
        public async Task FetchMatchDetailsAPIAsync_Should_Return_Valid_MatchDetail_ForValidMatchUid()
        {
            var matchUid = "test_uid";
            var mockService = new Moq.Mock<IMatchDetailService>();
            var expectedDto = new MatchDetailsDto { MatchUid = matchUid };

            mockService.Setup(s => s.FetchMatchDetailsAPIAsync(matchUid)).ReturnsAsync(expectedDto);

            var result = await mockService.Object.FetchMatchDetailsAPIAsync(matchUid);

            Assert.NotNull(result); 
            Assert.Equal(result.MatchUid, matchUid);
        }

        [Fact]
        public async Task GetFromDBAsync_Should_Return_Valid_MatchDetail_ForValidMatchUid()
        {
            var matchUid = "test_uid";
            var mockService = new Moq.Mock<IMatchDetailService>();
            var expectedDetail = new MatchDetail{ MatchUid = matchUid };

            mockService.Setup(s => s.GetFromDBAsync(matchUid)).ReturnsAsync(expectedDetail);

            var result = await mockService.Object.GetFromDBAsync(matchUid);

            Assert.NotNull(result);
            Assert.Equal(result.MatchUid, matchUid);
        }

        [Fact]
        public async Task GetFromAPIAsync_Should_Return_Valid_MatchDetailResponse_ForValidMatchUid()
        {
            //Arrange
            var matchUid = "test_uid";
            var mockService = new Moq.Mock<IMatchDetailService>();
            MatchDetail matchDetail = new MatchDetail();
            matchDetail.MatchUid = matchUid;
            var expectedDetail = new MatchDetailResponse { MatchDetails = matchDetail };

            mockService.Setup(s => s.GetFromAPIAsync(matchUid)).ReturnsAsync(expectedDetail);

            //Act
            var result = await mockService.Object.GetFromAPIAsync(matchUid);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.MatchDetails.MatchUid, matchUid);
        }
    }
}
