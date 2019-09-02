namespace MoviesService.Service.Models
{
    /// <summary>
    /// Movie rating model object
    /// </summary>
    public class UserMovieRating
    {
        /// <summary>
        /// Identifier for this user rating
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Movie Id
        /// </summary>
        public string MovieId { get; set; }

        /// <summary>
        /// User id 
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Rating given by the user for the movie
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Movie associated to this rating
        /// </summary>
        public Movie Movie { get; set; } 

    }
}
