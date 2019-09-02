using Microsoft.EntityFrameworkCore;
using MoviesService.Service.Models;

namespace MoviesService.Service.Repository
{
    /// <summary>
    /// Database context for the inmemory database 
    /// </summary>
    public class MovieServiceDbContext : DbContext
    {
        public MovieServiceDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<UserMovieRating> UserMovieRatings { get; set; }
    }
}
