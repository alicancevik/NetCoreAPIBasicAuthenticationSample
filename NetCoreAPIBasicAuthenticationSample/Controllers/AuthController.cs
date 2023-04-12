using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using NetCoreAPIBasicAuthenticationSample.Models;
using NetCoreAPIBasicAuthenticationSample.Services;
using AuthorizeAttribute = NetCoreAPIBasicAuthenticationSample.Models.AuthorizeAttribute;

namespace NetCoreAPIBasicAuthenticationSample.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            var user = _userService.Login(model.Username, model.Password);

            if (user == null)
            {
                return NotFound("Kullanıcı adı veya şifre yanlış!");
            }

            user.Password = "";

            return Ok(user);
        }

        [HttpGet("profile")]
        [Authorize]
        public IActionResult Profile()
        {
            return Ok("Profile");
        }


        [HttpGet("profile2")]
        public IActionResult Profile2()
        {
            return Ok("Profile");
        }
    }
}
