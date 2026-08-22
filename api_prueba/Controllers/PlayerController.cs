using Microsoft.AspNetCore.Mvc;
using dao_library;
using System.Collections.Generic;

namespace api_prueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerDao _playerDao = new PlayerDao();

        [HttpGet]
        public ActionResult<List<Player>> GetAll()
        {
            return Ok(_playerDao.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Player> GetById(int id)
        {
            var player = _playerDao.GetById(id);
            if (player == null)
            {
                return NotFound($"No se encontró al jugador con el ID {id}");
            }
            return Ok(player);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Player player)
        {
            _playerDao.Add(player);
            return Ok(new { message = "Jugador agregado con éxito" });
        }

        [HttpPut]
        public ActionResult Update([FromBody] Player player)
        {
            _playerDao.Update(player);
            return Ok(new { message = "Jugador actualizado con éxito" });
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _playerDao.Delete(id);
            return Ok(new { message = "Jugador eliminado con éxito" });
        }
    }
}