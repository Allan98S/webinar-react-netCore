using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesApiFull.Models.Common
{
    public class HeroeModel
    {
        public long? IdHeroe { get; set; }

        public string Name { get; set; }
        public string Power { get; set; }
        public string Company { get; set; }
        public bool? IsAlive { get; set; }

    }
}
