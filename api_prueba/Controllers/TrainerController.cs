using Microsoft.AspNetCore.Mvc;
using dao_library;
using System.Collections.Generic;

namespace api_prueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainerController : ControllerBase
    {
        private readonly TrainerDao _trainerDao = new TrainerDao();

        [HttpGet]
        public ActionResult<List<Trainer>> GetAll() => Ok(_trainerDao.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Trainer> GetById(int id)
        {
            var trainer = _trainerDao.GetById(id);
            return trainer == null ? NotFound($"No se encontró el entrenador con ID {id}") : Ok(trainer);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Trainer trainer)
        {
            _trainerDao.Add(trainer);
            return Ok(new { message = "Entrenador agregado con éxito" });
        }

        [HttpPut]
        public ActionResult Update([FromBody] Trainer trainer)
        {
            _trainerDao.Update(trainer);
            return Ok(new { message = "Entrenador actualizado con éxito" });
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _trainerDao.Delete(id);
            return Ok(new { message = "Entrenador eliminado con éxito" });
        }
    }
}