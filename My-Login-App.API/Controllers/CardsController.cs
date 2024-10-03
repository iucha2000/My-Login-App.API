﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Login_App.API.Models;
using My_Login_App.API.Packages;


namespace My_Login_App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        [Authorize]
        [HttpPost("Add-Card")]
        public IActionResult AddCard(CardRequest card)
        {
            PKG_CARDS cardPKG = new PKG_CARDS();
            cardPKG.add_card(card);

            return Ok();
        }

        [Authorize]
        [HttpPut("Edit-Card/{id}")]
        public IActionResult EditCard(int id, CardRequest card)
        {
            PKG_CARDS cardPKG = new PKG_CARDS();
            cardPKG.edit_card(id, card);

            return Ok();
        }

        [Authorize]
        [HttpDelete("Delete-Card/{id}")]
        public IActionResult DeleteCard(int id)
        {
            PKG_CARDS cardPKG = new PKG_CARDS();
            cardPKG.delete_card(id);

            return Ok();
        }

        [Authorize]
        [HttpGet("Get-All-Cards")]
        public IActionResult GetCards()
        {
            PKG_CARDS cardPKG = new PKG_CARDS();
            List<CardResponse> cards = cardPKG.get_all_cards();

            return Ok(cards);
        }

        [Authorize]
        [HttpGet("Get-Card-By-Id/{id}")]
        public IActionResult GetCardById(int id)
        {
            PKG_CARDS cardPKG = new PKG_CARDS();
            CardResponse card = cardPKG.get_card_by_id(id);

            return Ok(card);
        }

    }
}
