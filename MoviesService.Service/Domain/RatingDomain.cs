using MoviesService.Contract;
using MoviesService.Service.Models;
using MoviesService.Service.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Movie = MoviesService.Contract.Movie;
using User = MoviesService.Contract.User;

namespace MoviesService.Service.Domain
{
    public class RatingDomain : IRatingDomain
    {
        readonly IRatingRepository _ratingRepository;
        readonly IMoviesDomain _moviesDomain;
        private readonly IUsersDomain _usersDomain;

        public RatingDomain(IRatingRepository ratingRepository, IMoviesDomain moviesDomain, IUsersDomain usersDomain)
        {
            _ratingRepository = ratingRepository;
            _moviesDomain = moviesDomain;
            _usersDomain = usersDomain;
        }
        public async Task SetAsync(SetUserMovieRatingRequest setMovieMovieRatingRequest)
        {
            Movie movie = await _moviesDomain.GetMovieAsync(setMovieMovieRatingRequest.MovieId);

            User user = await _usersDomain.GetUserAsync(setMovieMovieRatingRequest.UserId);

            if (movie == null || user == null)
            {
                throw new KeyNotFoundException("Movie or user not found");
            }

            await _ratingRepository.SetAsync(setMovieMovieRatingRequest.UserId, setMovieMovieRatingRequest.MovieId, setMovieMovieRatingRequest.Rating);

            //Do not await on this operation
            _moviesDomain.UpdateMovieRatings(setMovieMovieRatingRequest.MovieId);
        }

        public async Task<List<UserMovieRating>> SearchAsync(string movieId, string userId)
        {
            return await _ratingRepository.SearchAsync(movieId, userId);
        }
    }
}
