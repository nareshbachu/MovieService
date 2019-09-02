using MoviesService.Contract;
using MoviesService.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesService.Service.Domain
{
    public interface IRatingDomain
    {
        /// <summary>
        /// Set movie rating for a user by request
        /// </summary>
        /// <param name="setMovieMovieRatingRequest"></param>
        /// <returns></returns>
        Task SetAsync(SetUserMovieRatingRequest setMovieMovieRatingRequest);

        /// <summary>
        /// Search movie rating my a movie id and user id
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<UserMovieRating>> SearchAsync(string movieId, string userId);
    }
}
