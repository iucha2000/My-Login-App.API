using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Login_App.API.Auth;
using My_Login_App.API.Interfaces;
using My_Login_App.API.Models;
using My_Login_App.API.Packages;

namespace My_Login_App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtManager _jwtManager;
        private readonly IPKG_BASE<UserRequest,UserResponse> _usersRepo;

        public AuthenticationController(IJwtManager jwtManager, IPKG_BASE<UserRequest, UserResponse> usersRepo)
        {
            _jwtManager = jwtManager;
            _usersRepo = usersRepo;
        }

        [HttpPost]
        public IActionResult Authenticate(Login user)
        {
            UserResponse existingUser = _usersRepo.GetEntityByProperty(user.Username);
            if (existingUser != null && existingUser.Password == user.Password)
            {
                var token = _jwtManager.GetToken(existingUser);
                return Ok(token);
            }
            return Unauthorized(new { message = "Invalid credentials" });
        }
    }
}
