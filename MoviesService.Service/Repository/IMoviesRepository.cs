using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesService.Service.Models;

namespace MoviesService.Service.Repository
{
    /// <summary>
    /// Movie repository
    /// </summary>
    public interface IMoviesRepository
    {
        /// <summary>
        /// Get all movies 
        /// </summary>
        /// <returns></returns>
        Task<List<Movie>> GetAllMoviesAsync();

        /// <summary>
        /// Update a movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        Task UpdateMovieAsync(Movie movie);


        /// <summary>
        /// Get movie by id
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task<Movie> GetMovieAsync(string movieId);


        /// <summary>
        /// Get multiple movies 
        /// </summary>
        /// <param name="movieIds"></param>
        /// <returns></returns>
        Task<List<Movie>> GetMoviesAsync(List<string> movieIds);
    }
}