using dao_library;
using entity_library;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api_prueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentDao _studentDao = new StudentDao();

        [HttpGet]
        public ActionResult<List<Student>> GetAll() => Ok(_studentDao.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            var student = _studentDao.GetById(id);
            if (student == null) return NotFound("Estudiante no encontrado");
            return Ok(student);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Student student)
        {
            _studentDao.Add(student);
            return Ok("Estudiante agregado correctamente");
        }

        [HttpPut]
        public ActionResult Update([FromBody] Student student)
        {
            _studentDao.Update(student);
            return Ok("Estudiante actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _studentDao.Delete(id);
            return Ok("Estudiante eliminado correctamente");
        }
    }
}