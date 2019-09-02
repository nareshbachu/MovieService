using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MoviesService.Contract;
using MoviesService.Service.Controllers;
using MoviesService.Service.Domain;
using System.Threading.Tasks;
using Xunit;

namespace MoviesService.UnitTests
{
    [Trait("Category", "RatingFixture")]
    public class RatingFixture
    {
        private RatingController _ratingController;
        private Mock<IRatingDomain> _ratingDomainMock;
        public RatingFixture()
        {
            _ratingDomainMock = new Mock<IRatingDomain>();
            _ratingController = new RatingController(_ratingDomainMock.Object);
        }

        [Fact]
        public async Task SetUserRating_FailureForInvalidRating()
        {
            var response = await _ratingController.SetUserRatingAsync(new SetUserMovieRatingRequest
            {
                Rating = -5
            });

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public async Task SetUserRating_FailureForInvalidUser()
        {

            _ratingDomainMock.Setup(x => x.SetAsync(It.IsAny<SetUserMovieRatingRequest>()))
                .Returns(() => throw new KeyNotFoundException(""));
            var response = await _ratingController.SetUserRatingAsync(new SetUserMovieRatingRequest
            {
                MovieId = "33444-55-55-55",
                UserId = "ddfdfd-dfdf-dfddd",
                Rating = 5
            });

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async Task SetUserRating_Success()
        {

            _ratingDomainMock.Setup(x => x.SetAsync(It.IsAny<SetUserMovieRatingRequest>())).Returns(Task.CompletedTask);
            var response = await _ratingController.SetUserRatingAsync(new SetUserMovieRatingRequest
            {
                MovieId = "33444-55-55-55",
                UserId = "ddfdfd-dfdf-dfddd",
                Rating = 5
            });

            Assert.IsType<OkResult>(response);
        }


    }
}