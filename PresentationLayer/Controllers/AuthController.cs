using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
     /*
      * Authentication Controller Api Layer
      */
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("VerifyPassword")]
        public IActionResult VerifyPassword(string nationalityId, string password)
        {
            var response = _authService.VerifyPassword(nationalityId, password);
            return Ok(response);
        }

        [HttpPost("Login")]
        public IActionResult Login(string nationalityId, string password)
        {
            var response = _authService.Login(nationalityId,password);
            return Ok(response);
        }
    }
}
