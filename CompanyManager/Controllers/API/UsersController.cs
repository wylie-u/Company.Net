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
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(UserViewModel user)
        {
            var users = await _userRepository.GetUsersAsync();

            if (users == null)
            {
                return NotFound();
            }

            //var response = new UsersResponse() { Users = users };
            return Ok(users);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetUserAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
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

            return View("Index");

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteUser(int id)
        //{
        //    var user = 
        //}
    }
}

