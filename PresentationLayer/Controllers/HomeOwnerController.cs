using BusinessLayer.Abstract;
using DataTransferObject.User;
using DataTransferObject.User.Requests;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeOwnerController:ControllerBase
    {
        private readonly IHomeOwnerService _ownerService;

        public HomeOwnerController(IHomeOwnerService userService)
        {
            _ownerService = userService;
        }

        [HttpPost("InsertOne")]
        public IActionResult InsertUserInfo(CreateHomeOwnerRequest request)
        {
            var resp = _ownerService.InsertUserInfo(request);
            return Ok(resp);
        }

        [HttpGet("GetuserInfo")]
        public IActionResult GetAll()
        {
            var data = _ownerService.getAllUserInfo();
            return Ok(data);
        }

        [HttpPut("UpdateUserInfo")]
        public IActionResult Update(UpdateHomeOwnerRequest request)
        {
            var resp = _ownerService.UpdateUserInfo(request);
            return Ok(resp);
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult Delete(int id)
        {
            var resp = _ownerService.DeleteUserInfo(id);
            return Ok(resp);
        }

    }
}
