using BusinessLayer.Abstract;
using DataTransferObject.User;
using DataTransferObject.User.Requests;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public IActionResult Register(CreateUserRegisterRequest request)
        {
            var resp = _userService.Register(request);
            return Ok(resp);
        }

        [HttpPost("InsertOne")]
        public IActionResult InsertUserInfo(CreateHomeOwnerRequest request)
        {
            var resp = _userService.InsertUserInfo(request);
            return Ok(resp);
        }

        [HttpGet("GetuserInfo")]
        public IActionResult GetAll()
        {
            var data = _userService.getAllUserInfo();
            return Ok(data);
        }

        [HttpPut("UpdateUserInfo")]
        public IActionResult Update(UpdateHomeOwnerRequest request)
        {
            var resp = _userService.UpdateUserInfo(request);
            return Ok(resp);
        }

        [HttpDelete("DeleteUserInfo")]
        public IActionResult Delete(User user)
        {
            var resp = _userService.DeleteUserInfo(user);
            return Ok(resp);
        }

    }
}
