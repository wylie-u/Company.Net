using System;
using CompanyManager.Models;

namespace CompanyManager.Repositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<User> GetUserAsync(int id);
        public Task AddUserAsync(User user);
        //public Task DeleteUserAsync(User user);
    }
}

