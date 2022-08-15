using BusinessLayer.Abstract;
using BusinessLayer.Configuration.Auth;
using DataTransferObject.Building.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Entities;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) // Getting Building Information By Id
        {
            var data = _buildingService.GetBuildingInfoById(id);
            return Ok(data);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() // Getting All Building Information
        {
            var data = _buildingService.GetAllBuildingInfo();
            return Ok(data);
        }

        [HttpPost("AddBuildingInfo")]
        public IActionResult AddBuildingInfo(CreateBuildingInformationRequest req) // Adding a building information
        {
            var resp = _buildingService.InsertBuildingInfo(req);
            return Ok(resp);
        }

        [HttpPut("UpdateBuildingInfo/{id}")]
        public IActionResult UpdateBuildingInfo(UpdateBuildingInformationRequest req) // Updating a building information
        {
            var resp = _buildingService.UpdateBuildingInfo(req);
            return Ok(resp);
        }

        [HttpDelete("DeleteBuildingInfo/{id}")]
        public IActionResult DeleteBuildingInfo(int id) // Deleting a building information
        {
            _buildingService.DeleteBuildingInfo(id);
            return Ok($"{id}'e ait Kat Bilgisi Silindi");
            
        }
    }
}
