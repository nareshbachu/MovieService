using MoviesService.Contract;
using MoviesService.Service.Extensions;
using MoviesService.Service.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesService.Service.Domain
{
    public class MoviesDomain : IMoviesDomain
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IRatingRepository _ratingRepository;
        public MoviesDomain(IMoviesRepository moviesRepository, IRatingRepository ratingRepository)
        {
            _moviesRepository = moviesRepository;
            //I had some circular references with movies and rating domains.
            //Ideally a domain should only talk directly with its own repository, shouldn't be talking to other repositories
            _ratingRepository = ratingRepository;
        }
        public async Task<List<Movie>> SearchMoviesAsync(SearchMoviesRequest searchMoviesRequest)
        {
            var allMovies = await _moviesRepository.GetAllMoviesAsync();
            return allMovies.Where(x=> !string.IsNullOrEmpty(searchMoviesRequest.SearchString) && x.Title.Contains(searchMoviesRequest.SearchString)
                                    && (!searchMoviesRequest.YearOfRelease.HasValue || x.YearOfRelease == searchMoviesRequest.YearOfRelease)
                                    && (searchMoviesRequest.Genres == null || searchMoviesRequest.Genres.Count == 0 || x.Genres.Split(",").Intersect(searchMoviesRequest.Genres).ToList().Count > 0)
                                    ).Select(m => m.ToMovieContractObject()).ToList();
        }

        public async Task<Movie> GetMovieAsync(string movieId)
        {
            Models.Movie movie = await _moviesRepository.GetMovieAsync(movieId);
            return movie?.ToMovieContractObject();
        }

        public async Task UpdateMovieRatings(string movieId)
        {
            Models.Movie movie = await _moviesRepository.GetMovieAsync(movieId);
            if (movie != null)
            {
                var userRatings = await _ratingRepository.SearchAsync(movieId, null);
                movie.AverageRating = Utility.RoundToNearest(userRatings.Select(x => x.Rating).Average());
                await _moviesRepository.UpdateMovieAsync(movie);
            }
        }

        public async Task<List<Movie>> GetTopRatedMoviesAsync(int countOfMoviesToReturn)
        {
            var allMovies = await _moviesRepository.GetAllMoviesAsync();
            return allMovies.OrderByDescending(x => x.AverageRating).ThenBy(x => x.Title).Take(countOfMoviesToReturn)
                .Select(x => x.ToMovieContractObject()).ToList();
        }

        public async Task<List<Movie>> GetTopRatedMoviesByUserAsync(string userId, int countOfMoviesToReturn)
        {
            var userRatings = await _ratingRepository.SearchAsync(null, userId);
            var movies = userRatings.OrderByDescending(x => x.Rating).ThenBy(x=>x.Movie.Title)
                .Take(countOfMoviesToReturn).Select(x => x.Movie).ToList();
            return movies.Select(x => x.ToMovieContractObject()).ToList();
        }
    }
}