using Microsoft.AspNetCore.Mvc;
using My_Login_App.API.Models;
using My_Login_App.API.Packages;


namespace My_Login_App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        [HttpPost("Add-Card")]
        public IActionResult AddCard(CardRequest card)
        {
            PKG_CARDS cardPKG = new PKG_CARDS();
            cardPKG.add_card(card);

            return Ok();
        }

        [HttpPut("Edit-Card")]
        public IActionResult EditCard(int id, CardRequest card)
        {
            PKG_CARDS cardPKG = new PKG_CARDS();
            cardPKG.edit_card(id, card);

            return Ok();
        }

        [HttpDelete("Delete-Card/{id}")]
        public IActionResult DeleteCard(int id)
        {
            PKG_CARDS cardPKG = new PKG_CARDS();
            cardPKG.delete_card(id);

            return Ok();
        }

        [HttpGet("Get-All-Cards")]
        public IActionResult GetCards()
        {
            PKG_CARDS cardPKG = new PKG_CARDS();
            List<CardResponse> cards = cardPKG.get_all_cards();

            return Ok(cards);
        }

    }
}
