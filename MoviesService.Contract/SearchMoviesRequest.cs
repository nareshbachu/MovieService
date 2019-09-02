using System;
using System.Collections.Generic;

namespace MoviesService.Contract
{
    /// <summary>
    /// Search request to search for movies
    /// </summary>
    public class SearchMoviesRequest
    {
        /// <summary>
        /// Search string to search against title of the movie
        /// </summary>
        public string SearchString { get; set; }

        /// <summary>
        /// Year of release
        /// </summary>
        public int? YearOfRelease { get; set; }

        /// <summary>
        /// Searches to match one of the given Genres
        /// </summary>
        public List<string> Genres { get; set; }

    }
}
