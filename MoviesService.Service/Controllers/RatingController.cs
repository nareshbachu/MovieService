using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesService.Contract;
using MoviesService.Service.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesService.Service.Controllers
{
    [Route("ratings")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingDomain _ratingDomain;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="ratingDomain">Rating controller instance</param>
        public RatingController(IRatingDomain ratingDomain)
        {
            _ratingDomain = ratingDomain;
        }


        [Route("set")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SetUserRatingAsync([FromBody] SetUserMovieRatingRequest userRatingRequest)
        {
            if (string.IsNullOrEmpty(userRatingRequest?.UserId) 
                || string.IsNullOrEmpty(userRatingRequest.MovieId) 
                || userRatingRequest.Rating > 5
                || userRatingRequest.Rating < 1)
                return BadRequest();
            try
            {
                await _ratingDomain.SetAsync(userRatingRequest);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}