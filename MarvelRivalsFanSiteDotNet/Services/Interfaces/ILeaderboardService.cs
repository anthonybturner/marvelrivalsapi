using MarvelRivalsFanSiteDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelRivalsFanSiteDotNet.Services.Interfaces
{
    public interface ILeaderboardService
    {
        Task<HeroBoardResponse> GetHeroBoardPlayersAsync(string heroName, string sortBy = "rank", bool ascending = false);
        Task<HeroBoardResponse> GetHeroBoardPlayers(int id);
    }
}
