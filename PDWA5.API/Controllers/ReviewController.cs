using Microsoft.AspNetCore.Mvc;
using PDWA5.Domain.Exceptions;
using PDWA5.Domain.Interface.Service;
using PDWA5.Domain.Models.DTO;
using System.Net;
using System.Net.Mime;

namespace PDWA5.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        /// <summary>
        /// Rota de busca de Review individual.
        /// </summary>
        /// <param name="id">Id da Review solicitada.</param>
        /// <returns>Objeto do tipo ReviewDto com as informações da Review solicitada.</returns>
        /// <response code="200">Review solicitada.</response>
        /// <response code="404">Review solicitada não encontrada.</response>
        /// <response code="500">Erro interno do Servidor.</response>
        [HttpGet("{id:int}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReviewDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetailsDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetailsDto))]
        public async Task<ActionResult<ReviewDto>> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(_reviewService.GetById(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ProblemDetailsDto.Success(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ProblemDetailsDto.Error(ex.Message));
            }
        }

        /// <summary>
        /// Rota de busca de lista de Reviews.
        /// </summary>
        /// <returns>Lista de objetos do tipo ReviewDto com todas as Reviews cadastradas no sistema.</returns>
        /// <response code="200">Reviews solicitadas.</response>
        /// <response code="404">Reviews solicitadas não encontradas.</response>
        /// <response code="500">Erro interno do Servidor.</response>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReviewDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetailsDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetailsDto))]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> Get()
        {
            try
            {
                return Ok(_reviewService.Get());
            }
            catch (NotFoundException ex)
            {
                return NotFound(ProblemDetailsDto.Success(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ProblemDetailsDto.Error(ex.Message));
            }
        }

        /// <summary>
        /// Rota de Cadastro de Reviews.
        /// </summary>
        /// <param name="review">Objeto do tipo ReviewDto informando as informações básicas da Review.</param>
        /// <returns>Novo objeto ReviewDto após seu registro.</returns>
        /// <response code="201">Review cadastrada.</response>
        /// <response code="400">Informações inconsistentes no cadastro da Review.</response>
        /// <response code="500">Erro interno do Servidor.</response>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ReviewDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetailsDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetailsDto))]
        public async Task<ActionResult<ReviewDto>> Add([FromBody] CreateReviewDto review)
        {
            try
            {
                return Created("", _reviewService.Add(review));
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ProblemDetailsDto.Error(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ProblemDetailsDto.Error(ex.Message));
            }
        }

        /// <summary>
        /// Rota de Atualização de Review.
        /// </summary>
        /// <param name="review">Objeto do tipo ReviewDto informando as informações da Review a ser atualizada.</param>
        /// <returns>Novo objeto ReviewDto após sua registro.</returns>
        /// <response code="200">Review atualizada.</response>
        /// <response code="400">Informações inconsistentes no cadastro da Review.</response>
        /// <response code="404">Review solicitada não encontrada.</response>
        /// <response code="500">Erro interno do Servidor.</response>
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReviewDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetailsDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetailsDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetailsDto))]
        public async Task<ActionResult<ReviewDto>> Update([FromBody] ReviewDto review)
        {
            try
            {
                return Ok(_reviewService.Update(review));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ProblemDetailsDto.Success(ex.Message));
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ProblemDetailsDto.Error(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ProblemDetailsDto.Error(ex.Message));
            }
        }

        /// <summary>
        /// Método de Exclusão de Review.
        /// </summary>
        /// <param name="id">Id da Review a ser excluída.</param>
        /// <returns></returns>
        /// <response code="204">Review excluída com sucesso.</response>
        /// <response code="404">Review solicitada não encontrada.</response>
        /// <response code="500">Erro interno do Servidor.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetailsDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetailsDto))]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                _reviewService.DeleteById(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ProblemDetailsDto.Success(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ProblemDetailsDto.Error(ex.Message));
            }
        }
    }
}
