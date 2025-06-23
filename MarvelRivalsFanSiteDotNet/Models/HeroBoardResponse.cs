using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelRivalsFanSiteDotNet.Models
{
    public class HeroBoardResponse
    {
        public List<HeroBoardPlayer> Players { get; set; }
        public int TotalPlayers { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}