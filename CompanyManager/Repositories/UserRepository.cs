using System;
using CompanyManager.Models;
using LiteDB;

namespace CompanyManager.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILiteCollection<User> _collection;

        public UserRepository(ILiteDatabase database)
        {
            _collection = database.GetCollection<User>();
        }

        public Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = _collection.FindAll();

            return Task.FromResult(users);
        }

        public Task<User> GetUserAsync(int id)
        {
            var user = _collection.FindById(id);

            return Task.FromResult(user);
        }

        public Task AddUserAsync(User user)
        {
            _collection.Insert(user);

            return Task.CompletedTask;
        }

        //public Task DeleteUserAsync(User user)
        //{
        //    _collection.Delete(user.Id);

        //    return Task.CompletedTask;
        //}
    }
}

