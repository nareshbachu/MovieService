using System.Threading.Tasks;
using MoviesService.Service.Models;

namespace MoviesService.Service.Repository
{
    /// <summary>
    /// User repository
    /// </summary>
    public interface IUsersRepository
    {
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<User> GetUserAsync(string userId);
    }
}