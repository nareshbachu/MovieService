using MoviesService.Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesService.Service.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MovieServiceDbContext _dbContext;
        public MoviesRepository(MovieServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await Task.Run(() =>_dbContext.Movies.ToList());
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            _dbContext.Movies.Update(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieAsync(string movieId)
        {
            return await _dbContext.Movies.FindAsync(movieId);
        }

        public async Task<List<Movie>> GetMoviesAsync(List<string> movieIds)
        {
            return _dbContext.Movies.Where(x=> movieIds.Contains(x.Id)).ToList();
        }
    }
}