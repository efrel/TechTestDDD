using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTestDDD.Contracts.Authentication;

namespace TechTestDDD.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            return Ok(request);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            return Ok(request);
        }
    }
}
