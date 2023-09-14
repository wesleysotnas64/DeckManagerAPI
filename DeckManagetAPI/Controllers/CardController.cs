using Microsoft.AspNetCore.Mvc;
using DeckManagerAPI.Entities;
using DeckManagerAPI.Data;

namespace DeckManagerAPI.Controllers
{
    [ApiController]
    [Route("card-manager-api/")]
    public class CardController : ControllerBase
    {
        private readonly DBManagerCards dbmCards;
        public CardController()
        {
            dbmCards = new DBManagerCards();
        }

        [HttpGet("get-all-cards")]
        public IActionResult GetAllCards()
        {
            List<Card> cards = dbmCards.GetAllCards();

            return Ok(cards);
        }

        [HttpGet("get-card/{id}")]
        public IActionResult GetCard(int id)
        {
            Card card = dbmCards.GetCard(id);

            return Ok(card);
        }

        [HttpPost("add-card")]
        public IActionResult AddCard(Card card)
        {
            dbmCards.AddCard(card);

            return CreatedAtAction(nameof(GetCard), new { id = card.Id }, card);
        }

        [HttpPut("update-card")]
        public IActionResult UpdateCard(Card card)
        {
            dbmCards.UpdateCard(card);

            return NoContent();
        }

        [HttpDelete("delete-card/{id}")]
        public IActionResult DeleteCard(int id)
        {
            dbmCards.DeleteCard(id);

            return NoContent();
        }
    }
}
