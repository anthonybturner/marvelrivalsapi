using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelRivalsFanSiteDotNet.Models
{

    public class HeroesResponse
    {
        public List<Hero> heroes;
    }

    public class HeroResponse
    {
        [JsonProperty("hero")]
        public Hero Hero { get; set; }
    }



}