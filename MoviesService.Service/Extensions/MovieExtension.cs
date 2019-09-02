using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using MoviesService.Contract;

namespace MoviesService.Service.Extensions
{
    public static class MovieExtension
    {
        public static Movie ToMovieContractObject(this Models.Movie movieModelObject)
        {
            Movie movieContractObject = new Movie();
            movieContractObject.Id = movieModelObject.Id;
            movieContractObject.Title = movieModelObject.Title;
            movieContractObject.YearOfRelease = movieModelObject.YearOfRelease;
            movieContractObject.RunningTime = movieModelObject.RunningTime;
            movieContractObject.AverageRating = movieModelObject.AverageRating;
            movieContractObject.Genres = movieModelObject.Genres.Split(",").ToList();
            return movieContractObject;
        }
    }
}