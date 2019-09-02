using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesService.Service.Models;

namespace MoviesService.Service.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly MovieServiceDbContext _dbContext;
        public UsersRepository(MovieServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetUserAsync(string userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }
    }
}
