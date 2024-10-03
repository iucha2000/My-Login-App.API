using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Login_App.API.Auth;
using My_Login_App.API.Models;
using My_Login_App.API.Packages;

namespace My_Login_App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtManager jwtManager;

        public AuthenticationController(IJwtManager jwtManager)
        {
            this.jwtManager = jwtManager;
        }

        [HttpPost]
        public IActionResult Authenticate(Login user)
        {
            PKG_USERS userPKG = new PKG_USERS();
            User existingUser = userPKG.GetUser(user.Username);
            if (existingUser != null && existingUser.Password == user.Password)
            {
                var token = jwtManager.GetToken(user);
                return Ok(token);
            }
            return Unauthorized("Invalid credentials");
        }
    }
}
