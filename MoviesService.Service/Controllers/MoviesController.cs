using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesService.Contract;
using MoviesService.Service.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesService.Service.Controllers
{
    [Route("movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesDomain _moviesDomain;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="moviesDomain">Movies controller instance</param>
        public MoviesController(IMoviesDomain moviesDomain)
        {
            _moviesDomain = moviesDomain;
        }

        // POST api/values
        [Route("search")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode:StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchMoviesAsync([FromBody] SearchMoviesRequest searchMoviesRequest)
        {
            if (!(searchMoviesRequest != null &&
                (!string.IsNullOrEmpty(searchMoviesRequest.SearchString)
                 || searchMoviesRequest.YearOfRelease.HasValue
                 || searchMoviesRequest.Genres?.Count > 0)))
                return BadRequest();

            List<Movie> movies = await _moviesDomain.SearchMoviesAsync(searchMoviesRequest);
            if (!movies.HasAny())
                return NotFound();

            return Ok(movies);
        }

        // GET api/values
        [Route("top-n-rated-movies")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTopRatedMoviesAsync([FromQuery] int? countOfMoviesToReturn = 5)
        {
            if (!countOfMoviesToReturn.HasValue)
                return BadRequest();

            List<Movie> movies = await _moviesDomain.GetTopRatedMoviesAsync(countOfMoviesToReturn.Value);
            if (!movies.HasAny())
                return NotFound();

            return Ok(movies);
        }

        // GET api/values
        [Route("top-n-rated-movies-per-user")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTopRatedMoviesByUserAsync([FromQuery] string userId, int? countOfMoviesToReturn = 5)
        {
            if (string.IsNullOrEmpty(userId) || !countOfMoviesToReturn.HasValue)
                return BadRequest();
            
            List<Movie> movies = await _moviesDomain.GetTopRatedMoviesByUserAsync(userId, countOfMoviesToReturn.Value);
            if (!movies.HasAny())
                return NotFound();
            
            return Ok(movies);
           
        }
    }
}
