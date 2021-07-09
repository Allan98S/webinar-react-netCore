using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroesApiFull.Models.AddHeroe;
using HeroesApiFull.Models.DeleteHeroe;
using HeroesApiFull.Models.EditHeroe;
using HeroesApiFull.Models.GetAllHeroes;
using HeroesApiFull.Models.GetHeroeById;
using HeroesApiFull.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSV.Backend.Models;

namespace HeroesApiFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroeController : Controller
    {
        public readonly IHeroeService _heroeService;

        #region Constructors
        public HeroeController(IHeroeService heroeService)
        {
            this._heroeService = heroeService;

        }
        #endregion

        #region Methods

        /// <summary>
        /// This method adds a new heroe.
        /// </summary>
        /// <param name="model">The request model</param>
        /// <returns>A heroe response model</returns>
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AddHeroeResponseModel> GetById([FromBody] AddHeroeRequestModel request)
        {
            try
            {
                AddHeroeResponseModel response = this._heroeService.Add(request: request);


                if (response == null)
                {
                    return new NoContentResult();
                }
                return new OkObjectResult(response);
            }
            catch (BadRequestException badRequest)
            {
                return new BadRequestObjectResult(badRequest.Message);
            }
            catch (InternalServerException internalError)
            {
                return StatusCode(500, internalError.clientMessage);
            }
        }
        /// <summary>
        /// This method edits a  heroe.
        /// </summary>
        /// <param name="model">The request model</param>
        /// <returns>A heroe response model</returns>
        [HttpPost("Edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EditHeroeResponseModel> Edit([FromBody] EditHeroeRequestModel request)
        {
            try
            {
                EditHeroeResponseModel response = this._heroeService.Edit(request: request);


                if (response == null)
                {
                    return new NoContentResult();
                }
                return new OkObjectResult(response);
            }
            catch (BadRequestException badRequest)
            {
                return new BadRequestObjectResult(badRequest.Message);
            }
            catch (InternalServerException internalError)
            {
                return StatusCode(500, internalError.clientMessage);
            }
        }
        /// <summary>
        /// This method deletes a  heroe.
        /// </summary>
        /// <param name="model">The request model</param>
        [HttpPost("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete([FromBody] DeleteHeroeRequestModel request)
        {
            try
            {
                this._heroeService.Delete(request: request);
                return new OkResult();
            }
            catch (BadRequestException badRequest)
            {
                return new BadRequestObjectResult(badRequest.Message);
            }
            catch (InternalServerException internalError)
            {
                return StatusCode(500, internalError.clientMessage);
            }
        }

        /// <summary>
        /// This method gets all the heroes.
        /// </summary>
        /// <param name="model">The request model</param>
        /// <returns>A heroe response model</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<GetAllHeroesResponseModel> GetAll()
        {
            try
            {
                GetAllHeroesResponseModel response = this._heroeService.GetAll();


                if (response == null)
                {
                    return new NoContentResult();
                }
                return new OkObjectResult(response);
            }
            catch (BadRequestException badRequest)
            {
                return new BadRequestObjectResult(badRequest.Message);
            }
            catch (InternalServerException internalError)
            {
                return StatusCode(500, internalError.clientMessage);
            }
        }
        /// <summary>
        /// This method gets a heroe by unique id.
        /// </summary>
        /// <param name="model">The request model</param>
        /// <returns>A heroe response model</returns>
        [HttpPost("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<GetHeroeByIdResponseModel> GetById([FromBody] GetHeroeByIdRequestModel request)
        {
            try
            {
                GetHeroeByIdResponseModel response = this._heroeService.GetById(request: request);


                if (response == null)
                {
                    return new NoContentResult();
                }
                return new OkObjectResult(response);
            }
            catch (BadRequestException badRequest)
            {
                return new BadRequestObjectResult(badRequest.Message);
            }
            catch (InternalServerException internalError)
            {
                return StatusCode(500, internalError.clientMessage);
            }
        }

        #endregion
    }
}