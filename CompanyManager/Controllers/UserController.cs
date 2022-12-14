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

        public IActionResult Index()
        {
            return View();
        }

       //working
       [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(UserViewModel user)
        {
            var users = await _userRepository.GetUsersAsync();

            if (users == null)
            {
                return NotFound();
            }

            //var response = new UsersResponse() { Users = users };
            return View("Index", users);

        }

        // GET user/id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
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
        public async Task<ActionResult<IEnumerable<UserViewModel>>> AddUser(UserViewModel usermodel)
        {

            var user = new User()
            { };
            
            await _userRepository.AddUserAsync(user);

            if (user == null)
            {
                return NotFound();
            }

            return View("Index", user);

        }

        // PUT users/id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE users/id
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteUser(int id)
        //{
        //    var user = await _userRepository.GetUserAsync(id);

        //    if (user is null)
        //    {
        //        return NotFound();
        //    }

        //    await _userRepository.DeleteUserAsync(user);

        //    return RedirectToAction("Index");
        //}
    }
}

