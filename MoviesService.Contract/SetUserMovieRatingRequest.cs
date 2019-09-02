namespace MoviesService.Contract
{
    /// <summary>
    /// Request to add or update a movie rating for a given user
    /// </summary>
    public class SetUserMovieRatingRequest
    {
        /// <summary>
        /// The id of the user giving this rating
        /// </summary>
        public string UserId;

        /// <summary>
        /// Movie id to add rating
        /// </summary>
        public string MovieId;

        /// <summary>
        /// Rating given by the user (should be between 1 and 5)
        /// </summary>
        public int Rating;

    }
}