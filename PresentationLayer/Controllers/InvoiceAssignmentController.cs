using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Helper.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceAssignmentController : Controller
    {
        private readonly IHomeOwnerService _ownerService;
        private readonly IOutcomeCalculator _calculator;

        public InvoiceAssignmentController(IHomeOwnerService ownerService, IOutcomeCalculator calculator)
        {
            _ownerService = ownerService;
            _calculator = calculator;
        }

        [HttpPost("AddFee")]
        public IActionResult AddFee(decimal price) // Assign Fee to all HomeOwners
        {
            _calculator.BillAssigner(price);
            var entity = _ownerService.getAllUserInfo();
            int cnt = entity.Count();
            return Ok(_calculator.BillCalculator(price,cnt)+" TL");
        }
    }
}
