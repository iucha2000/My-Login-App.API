using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Login_App.API.Interfaces;
using My_Login_App.API.Models;
using My_Login_App.API.Packages;


namespace My_Login_App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IPKG_BASE<CardRequest,CardResponse> _cardsRepo;

        public CardsController(IPKG_BASE<CardRequest, CardResponse> cardsRepo)
        {
            _cardsRepo = cardsRepo;
        }

        [Authorize]
        [HttpPost("Add-Card")]
        public IActionResult AddCard(CardRequest card)
        {
            _cardsRepo.AddEntity(card);

            return Ok();
        }

        [Authorize]
        [HttpPut("Edit-Card/{id}")]
        public IActionResult EditCard(int id, CardRequest card)
        {
            _cardsRepo.UpdateEntity(id, card);

            return Ok();
        }

        [Authorize]
        [HttpDelete("Delete-Card/{id}")]
        public IActionResult DeleteCard(int id)
        {
            _cardsRepo.DeleteEntity(id);

            return Ok();
        }

        [Authorize]
        [HttpGet("Get-Card-By-Id/{id}")]
        public IActionResult GetCardById(int id)
        {
            CardResponse card = _cardsRepo.GetEntity(id);

            return Ok(card);
        }

        [Authorize]
        [HttpGet("Get-All-Cards")]
        public IActionResult GetCards()
        {
            List<CardResponse> cards = _cardsRepo.GetAllEntities();

            return Ok(cards);
        }

    }
}
