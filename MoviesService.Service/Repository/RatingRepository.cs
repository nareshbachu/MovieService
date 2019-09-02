using MoviesService.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesService.Service.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly MovieServiceDbContext _dbContext;
        private readonly IMoviesRepository _movieRepository;

        public RatingRepository(MovieServiceDbContext dbContext, IMoviesRepository movieRepository)
        {
            _dbContext = dbContext;
            _movieRepository = movieRepository;
        }

        public async Task SetAsync(string userId, string movieId, int rating)
        {
            bool isNewRating = false;
            UserMovieRating userMovieRating = _dbContext.UserMovieRatings.FirstOrDefault(
                r => r.UserId == userId && r.MovieId == movieId);

            if (userMovieRating == null)
            {
                isNewRating = true;
                userMovieRating = new UserMovieRating
                {
                    Id = Guid.NewGuid().ToString(),
                    MovieId = movieId,
                    UserId = userId
                };
            }

            userMovieRating.Rating = rating;

            if (isNewRating)
                await _dbContext.UserMovieRatings.AddAsync(userMovieRating);
            else
                _dbContext.UserMovieRatings.Update(userMovieRating);

            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<UserMovieRating>> SearchAsync(string movieId, string userId)
        {
            List<UserMovieRating> userMovieRatings = new List<UserMovieRating>();

            if (!string.IsNullOrEmpty(movieId) && !string.IsNullOrEmpty(userId))
                userMovieRatings = _dbContext.UserMovieRatings.Where(x => x.MovieId == movieId && x.UserId == userId).ToList();
            else if(!string.IsNullOrEmpty(movieId))
                userMovieRatings = _dbContext.UserMovieRatings.Where(x => x.MovieId == movieId).ToList();
            else if (!string.IsNullOrEmpty(userId))
                userMovieRatings = _dbContext.UserMovieRatings.Where(x => x.UserId == userId).ToList();

            List<Movie> movies = await _movieRepository.GetMoviesAsync(userMovieRatings.Select(x => x.MovieId).ToList());
            foreach (var userMovieRating in userMovieRatings)
            {
                userMovieRating.Movie = movies.FirstOrDefault(x => x.Id == userMovieRating.MovieId);
            }

            return userMovieRatings;
        }
    }
}