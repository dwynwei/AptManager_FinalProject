using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Configuration.Auth;
using DataTransferObject.CreditCard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.MongoEntites;
using MongoDB.Bson;
using MongoDB.Driver;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly CreditCardService _creditCardService;

        public CreditCardController(CreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync() // Async Get All Credit Card information
        {
            var data = await _creditCardService.Get();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id) // Async Get One Credit Card information by Id
        {
            var card = await _creditCardService.GetbyId(id);
            if (card == null)
                return NotFound($"{id} Bilgisine Sahip Kart Bulunamadı");
            else
            return Ok(card);
        }

        [HttpPost("AddCard")]
        public async Task<IActionResult> PostAsync(CreateCreditCardRequest card) // Async Add a Credit Card information
        {

            await _creditCardService.Create(card);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id ,[FromBody] UpdateCreditCardRequest card) // Async Update a Credit Card information by Id
        {
            var getCardId = await _creditCardService.GetbyId(id);
            if (getCardId == null)
                return NotFound($"{id}'e Ait Kart Bilgisi Bulunamadı");
            else
            {
                await _creditCardService.Update(id, card);
                return Ok($"{id}'e Ait Kart Bilgisi Güncellendi");
            }            
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string id) // Async Delete a Credit Card information
        {
            var getcardId = await _creditCardService.GetbyId(id);
            if (getcardId == null)
                return NotFound($"{id}'e Ait Kart Bilgisi Bulunamadı");
            else
            {
                await _creditCardService.Delete(id);
                return Ok($"{id}'e Ait Kart Bilgileri Silindi !");
            }            
        }
    }
}
