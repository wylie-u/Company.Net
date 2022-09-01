using System;
using CompanyManager.Models;

namespace CompanyManager.Repositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task AddUserAsync(User user);
    }
}

