using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesService.Service.Models;

namespace MoviesService.Service.Repository
{
    /// <summary>
    /// Rating repository 
    /// </summary>
    public interface IRatingRepository
    {
        /// <summary>
        /// Set movie rating for a give user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        /// <param name="rating"></param>
        /// <returns></returns>
        Task SetAsync(string userId, string movieId, int rating);

        //Search movie rating by a given user or movie id
        Task<List<UserMovieRating>> SearchAsync(string movieId, string userId);

    }
}
