using DeckManagerAPI.Data;
using DeckManagerAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeckManagerAPI.Controllers
{
    [ApiController]
    [Route("player-manager-api/")]
    public class PlayerController : ControllerBase
    {
        private readonly DBManagerPlayers dbmPlayers;
        public PlayerController()
        {
            dbmPlayers = new DBManagerPlayers();
        }

        [HttpGet("get-all-players")]
        public IActionResult GetAllPlayers()
        {
            List<Player> players = dbmPlayers.GetAllPlayers();

            return Ok(players);
        }

        [HttpGet("get-player/{login}")]
        public IActionResult GetPlayer(string login)
        {
            Player player = dbmPlayers.GetPlayer(login);

            return Ok(player);
        }

        [HttpPost("add-player")]
        public IActionResult AddPlayer(Player player)
        {
            dbmPlayers.AddPlayer(player);

            return CreatedAtAction(nameof(GetPlayer), new { login = player.Login }, player);
        }

        [HttpPut("update-player")]
        public IActionResult UpdatePlayer(Player player)
        {
            dbmPlayers.UpdatePlayer(player);

            return NoContent();
        }

        [HttpDelete("delete-player/{id}")]
        public IActionResult DeletePlayer(int id)
        {
            dbmPlayers.DeletePlayer(id);

            return NoContent();
        }
    }
}
