using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MoviesService.Contract;
using MoviesService.Service.Controllers;
using MoviesService.Service.Domain;
using Xunit;

namespace MoviesService.UnitTests
{
    public class MoviesFixture
    {
        private MoviesController _moviesController;
        private Mock<IMoviesDomain> _moviesDomainMock;
        public MoviesFixture()
        {
            _moviesDomainMock = new Mock<IMoviesDomain>();
            _moviesController = new MoviesController(_moviesDomainMock.Object);
        }

        [Fact]
        public async Task SearchMovies_FailureForNoSearchCriteria()
        {
            var response = await _moviesController.SearchMoviesAsync(new SearchMoviesRequest());

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public async Task SearchMovies_NoResult()
        {
            _moviesDomainMock.Setup(x => x.SearchMoviesAsync(It.IsAny<SearchMoviesRequest>())).Returns(Task.FromResult(new List<Movie>()));
            var response = await _moviesController.SearchMoviesAsync(new SearchMoviesRequest()
            {
                SearchString = "movie"
            });
            Assert.IsType<NotFoundResult>(response);
        }


        [Fact]
        public async Task SearchMovies_Success()
        {
            _moviesDomainMock.Setup(x => x.SearchMoviesAsync(It.IsAny<SearchMoviesRequest>())).
                Returns(Task.FromResult(new List<Movie>{new Movie {Title = "Movie", AverageRating = 5.0}}));
            var response = await _moviesController.SearchMoviesAsync(new SearchMoviesRequest()
            {
                SearchString = "movie"
            });
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
