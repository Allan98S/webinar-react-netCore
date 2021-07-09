using HeroesApiFull.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesApiFull.Models.GetAllHeroes
{
    public class GetAllHeroesResponseModel
    {
        public List<HeroeModel> Heroes { get; set; }

    }
}
