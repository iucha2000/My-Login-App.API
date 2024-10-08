using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Login_App.API.Interfaces;
using My_Login_App.API.Models;
using My_Login_App.API.Packages;

namespace My_Login_App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IPKG_BASE<UserRequest, UserResponse> _usersRepo;

        public UsersController(IPKG_BASE<UserRequest, UserResponse> usersRepo)
        {
            _usersRepo = usersRepo;
        }

        [HttpPost("Add-User")]
        public IActionResult AddUser(UserRequest user)
        {
            _usersRepo.AddEntity(user);

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Edit-User/{id}")]
        public IActionResult EditUser(int id, UserRequest user)
        {
            _usersRepo.UpdateEntity(id, user);

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete-User/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _usersRepo.DeleteEntity(id);

            return Ok();
        }

        [HttpGet("Get-User-By-Username/{username}")]
        public IActionResult GetUserByUsername(string username)
        {
            UserResponse user = _usersRepo.GetEntityByProperty(username);

            return Ok(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Get-All-Users")]
        public IActionResult GetCards()
        {
            List<UserResponse> users = _usersRepo.GetAllEntities();

            return Ok(users);
        }

    }
}
