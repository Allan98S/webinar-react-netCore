using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSV.Backend.Models;

namespace HeroesApiFull.Models.DeleteHeroe
{
    public class DeleteHeroeRequestModel:ModelValidator
    {
        public long? IdHeroe { get; set; }

        public void ValidateModel()
        {
            if (IdHeroe == null)
            {
                throw new BadRequestException("El id del heroe es requerido.");

            }
            if (IdHeroe <= 0)
            {
                throw new BadRequestException("El id del heroe debe ser mayor a 0.");

            }
        }
    }
}
