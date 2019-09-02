using MoviesService.Service.Repository;
using System.Threading.Tasks;
using MoviesService.Contract;
using MoviesService.Service.Extensions;

namespace MoviesService.Service.Domain
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;
        
        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<User> GetUserAsync(string userId)
        {
            Models.User user = await _usersRepository.GetUserAsync(userId);
            return user?.ToUserContractObject();
        }
    }
}
