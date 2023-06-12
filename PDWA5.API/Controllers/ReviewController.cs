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
        /// Individual Review GET Endpoint.
        /// </summary>
        /// <param name="id">Requested Review Id</param>
        /// <returns>Requested Review.</returns>
        /// <response code="200">Requested Review.</response>
        /// <response code="404">Review not found.</response>
        /// <response code="500">Internal Server Error.</response>
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
        /// Review list GET Endpoint.
        /// </summary>
        /// <returns>ReviewDto list.</returns>
        /// <response code="200">Requested Review.</response>
        /// <response code="404">Reviews not found.</response>
        /// <response code="500">Internal Server Error.</response>
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
        /// Review creation POST Endpoint.
        /// </summary>
        /// <param name="review">ReviewDto object to be created.</param>
        /// <returns>Created ReviewDto object.</returns>
        /// <response code="201">Review created.</response>
        /// <response code="400">Creating the Review wasn't possible due to incorrect information.</response>
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
        /// Review update PUT Endpoint.
        /// </summary>
        /// <param name="review">ReviewDto object to be updated.</param>
        /// <returns>Updated ReviewDto object.</returns>
        /// <response code="200">Review updated.</response>
        /// <response code="400">Updating the Review wasn't possible due to incorrect information.</response>
        /// <response code="404">Review not found.</response>
        /// <response code="500">Internal Server Error.</response>
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
        /// Review deletion DELETE Endpoint.
        /// </summary>
        /// <param name="id">Review id.</param>
        /// <returns></returns>
        /// <response code="204">Review deleted successfully.</response>
        /// <response code="404">Review not found.</response>
        /// <response code="500">Internal Server Error.</response>
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
