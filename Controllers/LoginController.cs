using api_rest.Models;
using api_rest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("/login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Login login)
        {
            if (login.Email == "test@mail.com" && login.Password == "123456")
            {
                var token = TokenGenerator.Build(login);
                return StatusCode(200, new { Token = token });
            }
            return StatusCode(401, new { Message = "Login or password is wrong" });
        }
    }
}
