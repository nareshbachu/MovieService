using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesService.Contract;

namespace MoviesService.Service.Domain
{
    /// <summary>
    /// Movies domain
    /// </summary>
    public interface IMoviesDomain
    {
        /// <summary>
        /// Search movies by request
        /// </summary>
        /// <param name="searchMoviesRequest"></param>
        /// <returns></returns>
        Task<List<Movie>> SearchMoviesAsync(SearchMoviesRequest searchMoviesRequest);

        /// <summary>
        /// Get movie by id
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task<Movie> GetMovieAsync(string movieId);

        /// <summary>
        /// Calculate and updated movie ratings by id
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task UpdateMovieRatings(string movieId);

        /// <summary>
        /// Get top n rated movies by all user
        /// </summary>
        /// <param name="countOfMoviesToReturn"></param>
        /// <returns></returns>
        Task<List<Movie>> GetTopRatedMoviesAsync(int countOfMoviesToReturn);

        /// <summary>
        /// Get top n rated movies by a given user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="countOfMoviesToReturn"></param>
        /// <returns></returns>
        Task<List<Movie>> GetTopRatedMoviesByUserAsync(string userId, int countOfMoviesToReturn);
    }
}