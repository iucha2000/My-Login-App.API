using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Login_App.API.Models;
using My_Login_App.API.Packages;

namespace My_Login_App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("Add-User")]
        public IActionResult AddCard(User user)
        {
            PKG_USERS userPKG = new PKG_USERS();
            userPKG.AddUser(user);

            return Ok();
        }

        [HttpGet("Get-User-By-Username/{username}")]
        public IActionResult GetCardById(string username)
        {
            PKG_USERS userPKG = new PKG_USERS();
            User user = userPKG.GetUser(username);
        
            return Ok(user);
        }
    }
}
