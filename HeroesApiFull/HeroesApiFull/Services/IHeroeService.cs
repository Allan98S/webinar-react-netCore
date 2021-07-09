using HeroesApiFull.Models.AddHeroe;
using HeroesApiFull.Models.DeleteHeroe;
using HeroesApiFull.Models.EditHeroe;
using HeroesApiFull.Models.GetAllHeroes;
using HeroesApiFull.Models.GetHeroeById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesApiFull.Services
{
    public interface IHeroeService
    {
        AddHeroeResponseModel Add(AddHeroeRequestModel request);

        EditHeroeResponseModel Edit(EditHeroeRequestModel request);

        GetAllHeroesResponseModel GetAll();

        GetHeroeByIdResponseModel GetById(GetHeroeByIdRequestModel request);

        void Delete(DeleteHeroeRequestModel request);


    }
}
