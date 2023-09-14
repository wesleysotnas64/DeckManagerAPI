using DeckManagerAPI.Data;
using DeckManagerAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeckManagerAPI.Controllers
{
    [ApiController]
    [Route("administrator-manager-api/")]
    public class AdministratorController : ControllerBase
    {
        private readonly DBManagerAdministrators dbmAdministrators;
        public AdministratorController()
        {
            dbmAdministrators = new DBManagerAdministrators();
        }

        [HttpGet("get-all-administrators")]
        public IActionResult GetAllAdministrators()
        {
            List<Administrator> administrators = dbmAdministrators.GetAllAdministrators();

            return Ok(administrators);
        }

        [HttpGet("get-administrator/{login}")]
        public IActionResult GetAdministrator(string login)
        {
            Administrator administrator = dbmAdministrators.GetAdministrator(login);

            return Ok(administrator);
        }

        [HttpPost("add-administrator")]
        public IActionResult AddAdministrator(Administrator administrator)
        {
            dbmAdministrators.AddAdministrator(administrator);

            return CreatedAtAction(nameof(GetAdministrator), new { login = administrator.Login }, administrator);
        }

        [HttpPut("update-administrator")]
        public IActionResult UpdateAdministrator(Administrator administrator)
        {
            dbmAdministrators.UpdateAdministrator(administrator);

            return NoContent();
        }

        [HttpDelete("delete-administrator/{id}")]
        public IActionResult DeleteAdministrator(int id)
        {
            dbmAdministrators.DeleteAdministrator(id);

            return NoContent();
        }
    }
}
