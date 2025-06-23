using MarvelRivalsFanSiteDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelRivalsFanSiteDotNet.Services.Interfaces
{
    public interface IHeroesService
    {

        Task<HeroesResponse> GetHeroesAsync();
    }
}
