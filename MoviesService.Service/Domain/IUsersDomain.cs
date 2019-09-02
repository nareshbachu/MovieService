using MoviesService.Contract;
using System.Threading.Tasks;

namespace MoviesService.Service.Domain
{
    /// <summary>
    /// Users domain
    /// </summary>
    public interface IUsersDomain
    {
        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<User> GetUserAsync(string userId);
    }
}
