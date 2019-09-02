using System.Collections.Generic;

namespace MoviesService.Contract
{
    /// <summary>
    /// Details of the movie
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Identifier for the movie
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Title for the movie
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The year of the release for the movie
        /// </summary>
        public int YearOfRelease { get; set; }

        /// <summary>
        /// The number of run minutes for the movie
        /// </summary>
        public int RunningTime { get; set; }

        /// <summary>
        /// All the genres this movie falls under
        /// </summary>
        public List<string> Genres { get; set; }

        /// <summary>
        /// The average user rating for the movie
        /// </summary>
        public double AverageRating { get; set; }
    } 
}