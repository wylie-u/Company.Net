using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyManager.Models;
using CompanyManager.Repositories;
using CompanyManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyManager.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET user/id
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST users
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(UserViewModel userViewModel)
        {
            var user = new User()
            {
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                Username = userViewModel.Username,
                Email = userViewModel.Email
            };

            await _userRepository.AddUserAsync(user);

            return Ok(user);
        }

        // PUT users/id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE users/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

