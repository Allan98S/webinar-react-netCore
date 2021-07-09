using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSV.Backend.Models;

namespace HeroesApiFull.Models.EditHeroe
{
    public class EditHeroeRequestModel : ModelValidator
    {
        public long? IdHeroe { get; set; }
        public string Name { get; set; }
        public string Power { get; set; }
        public string Company { get; set; }
        public bool? IsAlive { get; set; }

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
            if (string.IsNullOrEmpty(this.Name))
            {
                throw new BadRequestException("El nombre del heroe es requerido.");
            }
            if (string.IsNullOrEmpty(this.Power))
            {
                throw new BadRequestException("El poder del heroe es requerido.");
            }
            if (string.IsNullOrEmpty(this.Company))
            {
                throw new BadRequestException("La compañía del heroe es requeridq.");
            }
            if (this.Name.Length < 2)
            {
                throw new BadRequestException("El nombre del heroe no puede ser tan corto.");

            }
            if (this.Company.Length < 2)
            {
                throw new BadRequestException("La compañía del heroe no puede ser tan corta.");

            }
            if (this.Power.Length < 2)
            {
                throw new BadRequestException("El poder del heroe no puede ser tan corto.");

            }
            if (this.Name.Length > 50)
            {
                throw new BadRequestException("El nombre del heroe no puede ser mayor a 50 caracteres.");

            }
            if (this.Power.Length > 100)
            {
                throw new BadRequestException("El poder del heroe no puede ser mayor a 100 caracteres.");

            }
            if (this.Company.Length > 50)
            {
                throw new BadRequestException("La compañía del heroe no puede ser mayor a 50 caracteres.");

            }
            if (this.IsAlive == null)
            {
                throw new BadRequestException("El estado del heroe es requerido.");

            }
        }
    }
}
