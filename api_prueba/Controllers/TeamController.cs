using Microsoft.AspNetCore.Mvc;
using dao_library;
using System.Collections.Generic;

namespace api_prueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly TeamDao _teamDao = new TeamDao();

        [HttpGet]
        public ActionResult<List<Team>> GetAll() => Ok(_teamDao.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Team> GetById(int id)
        {
            var team = _teamDao.GetById(id);
            return team == null ? NotFound($"No se encontró el equipo con ID {id}") : Ok(team);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Team team)
        {
            _teamDao.Add(team);
            return Ok(new { message = "Equipo agregado con éxito" });
        }

        [HttpPut]
        public ActionResult Update([FromBody] Team team)
        {
            _teamDao.Update(team);
            return Ok(new { message = "Equipo actualizado con éxito" });
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _teamDao.Delete(id);
            return Ok(new { message = "Equipo eliminado con éxito" });
        }
    }
}