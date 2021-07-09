using HeroesApiFull.Entities;
using HeroesApiFull.Models.AddHeroe;
using HeroesApiFull.Models.Common;
using HeroesApiFull.Models.DeleteHeroe;
using HeroesApiFull.Models.EditHeroe;
using HeroesApiFull.Models.GetAllHeroes;
using HeroesApiFull.Models.GetHeroeById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSV.Backend.Models;

namespace HeroesApiFull.Services
{
    public class HeroeService : IHeroeService
    {
        private readonly DBContext _dbContext;

        public HeroeService(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }
        /// <summary>
        /// Adds a new heroe
        /// </summary>
        /// <param name="transactionCode">Unique code per transaction</param>
        /// <param name="model">The request model</param>
        /// <returns>The heroe response model</returns>
        public AddHeroeResponseModel Add(AddHeroeRequestModel request)
        {
            try
            {
                request.ValidateModel();

                AddHeroeResponseModel response = null;

                HeroeEntity newHeroe = new HeroeEntity
                {
                    Company = request.Company,
                    IsAlive = request.IsAlive,
                    Name = request.Name,
                    Power = request.Power
                };

                this._dbContext.Heroes.Add(newHeroe);
                this._dbContext.SaveChanges();

                response = new AddHeroeResponseModel
                {
                    Company = newHeroe.Company,
                    IsAlive = newHeroe.IsAlive,
                    Name = newHeroe.Name,
                    Power = newHeroe.Power,
                    IdHeroe = newHeroe.IdHeroe
                };

                return response;
            }
            catch (BadRequestException badRequest)
            {
                throw badRequest;
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, "Ha ocurrido un error interno, por favor inténtelo de nuevo.");
            }
        }
        /// <summary>
        /// Deletes a  heroe
        /// </summary>
        /// <param name="transactionCode">Unique code per transaction</param>
        /// <param name="model">The request model</param>
        public void Delete(DeleteHeroeRequestModel request)
        {
            try
            {
                HeroeEntity heroeToDelete = this._dbContext.Heroes.Find(request.IdHeroe);

                if (heroeToDelete != null)
                {
                    this._dbContext.Remove(heroeToDelete);
                    this._dbContext.SaveChanges();
                }
                else
                {
                    throw new BadRequestException($"El heroe con el id {request.IdHeroe} no existe");
                }
            }
            catch (BadRequestException badRequest)
            {
                throw badRequest;
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, "Ha ocurrido un error interno, por favor inténtelo de nuevo.");
            }

        }
        /// <summary>
        /// Edits a  heroe
        /// </summary>
        /// <param name="transactionCode">Unique code per transaction</param>
        /// <param name="model">The request model</param>
        /// <returns>The heroe response model</returns>
        public EditHeroeResponseModel Edit(EditHeroeRequestModel request)
        {
            try
            {
                request.ValidateModel();

                EditHeroeResponseModel response = null;

                HeroeEntity heroeToEdit = this._dbContext.Heroes.Find(request.IdHeroe);

                if (heroeToEdit != null)
                {
                    heroeToEdit.Name = request.Name;
                    heroeToEdit.Company = request.Company;
                    heroeToEdit.Power = request.Power;
                    heroeToEdit.IsAlive = request.IsAlive;

                    this._dbContext.Entry(heroeToEdit);
                    this._dbContext.SaveChanges();

                    response = new EditHeroeResponseModel
                    {
                        Company = heroeToEdit.Company,
                        IdHeroe = heroeToEdit.IdHeroe,
                        IsAlive = heroeToEdit.IsAlive,
                        Power = heroeToEdit.Power,
                        Name = heroeToEdit.Name
                    };

                    return response;
                }
                else
                {
                    throw new BadRequestException($"El heroe a editar con el id {request.IdHeroe} no existe.");
                }

            }
            catch (BadRequestException badRequest)
            {
                throw badRequest;
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, "Ha ocurrido un error interno, por favor inténtelo de nuevo.");
            }
        }
        /// <summary>
        /// Gets all the  heroes
        /// </summary>
        /// <param name="transactionCode">Unique code per transaction</param>
        /// <param name="model">The request model</param>
        /// <returns>The heroes response model</returns>
        public GetAllHeroesResponseModel GetAll()
        {
            try
            {
                GetAllHeroesResponseModel response = new GetAllHeroesResponseModel();
                response.Heroes = new List<HeroeModel>();

                List <HeroeEntity> heroesEntities = this._dbContext.Heroes.ToList();

                if(heroesEntities == null)
                {
                    return null;
                }
                else
                {
                    HeroeModel model = null;
                    foreach (var heroe in heroesEntities)
                    {
                        model = new HeroeModel
                        {
                            Company = heroe.Company,
                            IdHeroe = heroe.IdHeroe,
                            IsAlive = heroe.IsAlive,
                            Name = heroe.Name,
                            Power = heroe.Power
                        };
                        response.Heroes.Add(model);

                    }
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, "Ha ocurrido un error interno, por favor inténtelo de nuevo.");
            }
        }

        /// <summary>
        /// Gets a heroe by id.
        /// </summary>
        /// <param name="transactionCode">Unique code per transaction</param>
        /// <param name="model">The request model</param>
        /// <returns>The heroe response model</returns>
        public GetHeroeByIdResponseModel GetById(GetHeroeByIdRequestModel request)
        {
            try
            {
                request.ValidateModel();

                GetHeroeByIdResponseModel response = null;

                HeroeEntity heroeEntity = this._dbContext.Heroes.Find(request.IdHeroe);

                if(heroeEntity == null)
                {
                    throw new BadRequestException($"El heroe con el id: {request.IdHeroe} no existe.");
                }
                response = new GetHeroeByIdResponseModel
                {
                    Heroe = new HeroeModel
                    {
                        Company = heroeEntity.Company,
                        IdHeroe = heroeEntity.IdHeroe,
                        IsAlive = heroeEntity.IsAlive,
                        Name = heroeEntity.Name,
                        Power = heroeEntity.Power
                    }
                };
                return response;
            }
            catch (BadRequestException badRequest)
            {
                throw badRequest;
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, "Ha ocurrido un error interno, por favor inténtelo de nuevo.");
            }
        }
    }
}
