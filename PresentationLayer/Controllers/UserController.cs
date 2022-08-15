using BusinessLayer.Abstract;
using DataTransferObject.User.Requests;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public IActionResult Register(CreateUserRegisterRequest request) // Register a User Account to System
        {
            var resp = _userService.Register(request);
            return Ok(resp);
        }
    }
}
