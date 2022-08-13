using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataTransferObject.CreditCard;
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
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _creditCardService.Get();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var card = await _creditCardService.GetbyId(id);
            if (card == null)
                return NotFound($"{id} Bilgisine Sahip Kart Bulunamadı");
            else
            return Ok(card);
        }

        [HttpPost("AddCard")]
        public async Task<IActionResult> PostAsync(CreateCreditCardRequest card)
        {

            await _creditCardService.Create(card);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id ,[FromBody] UpdateCreditCardRequest card)
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
        public async Task<IActionResult> DeleteAsync(string id)
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
