using System;
using System.Collections.Generic;
using System.Linq;
using MoviesService.Service.Models;


namespace MoviesService.Service.Repository
{
    /// <summary>
    /// Seed data to load on service statup
    /// </summary>
    public class MovieServiceSeedData
    {
        public static void SeedData(MovieServiceDbContext dbContext)
        {
            if (dbContext.Movies.Any())
                return;

            Random random = new Random();
            List<string> genres = new List<string>{"Comedy", "Action", "Thriller", "Drama", "fiction"};
            List<string> userIds = new List<string>
                { "f3b8f0ba-8476-43db-8814-a95af30cebb9",
                "88116f04-ee0a-40aa-90ca-b54ef5eea075",
                "c3406ecd-cf96-46b5-a61f-a98ce6b24637",
                "df6056d0-d0c3-4526-9976-ef9e47e97c0c",
                "b5c80665-d77d-48df-8847-55246fa54f71"};
            List<Movie> movies = new List<Movie>();
            List<User> users = new List<User>();
            List<UserMovieRating> userMovieRatings = new List<UserMovieRating>();
            for (int i = 1; i <= 20; i++)
            {
                Movie movie = new Movie
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = $"Movie {i}",
                    YearOfRelease = 1999 + i,
                    RunningTime = 120 - i,
                    Genres = string.Join(",", genres.Take(random.Next(1,5)))
                };

                movies.Add(movie);
            }

            for (int i = 1; i <= 5; i++)
            {
                User user = new User()
                {
                    Id = userIds[i-1],
                    FullName = $"User {i}",
                    Email = $"useremail{i}@gmail.com"
                };
                users.Add(user);
            }

            for (int i = 1; i <= 100; i++)
            {
                string userId = users[random.Next(1,5)].Id;
                string movieId = movies[random.Next(1, 20)].Id;
                int rating = random.Next(1, 5);

                if (userMovieRatings.Exists(ur => ur.UserId == userId && ur.MovieId == movieId))
                    continue;

                UserMovieRating userMovieRating = new UserMovieRating
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = userId,
                    MovieId = movieId,
                    Rating = rating
                };
                userMovieRatings.Add(userMovieRating);
            }

            foreach (Movie movie in movies)
            {
                List<UserMovieRating> movieRatings = userMovieRatings.FindAll(x => x.MovieId == movie.Id);
                if (movieRatings.Count > 0)
                    movie.AverageRating = movieRatings.Select(x => x.Rating).Average();
                movie.AverageRating = Utility.RoundToNearest(movie.AverageRating);
            }
            
            dbContext.Movies.AddRange(movies);
            dbContext.Users.AddRange(users);
            dbContext.UserMovieRatings.AddRange(userMovieRatings);
            dbContext.SaveChanges();
        }
    }
}