using dao_library;
using entity_library;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api_prueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly CourseDao _courseDao = new CourseDao();

        [HttpGet]
        public ActionResult<List<Course>> GetAll() => Ok(_courseDao.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Course> GetById(int id)
        {
            var course = _courseDao.GetById(id);
            if (course == null) return NotFound("Curso no encontrado");
            return Ok(course);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Course course)
        {
            _courseDao.Add(course);
            return Ok("Curso agregado correctamente");
        }

        [HttpPut]
        public ActionResult Update([FromBody] Course course)
        {
            _courseDao.Update(course);
            return Ok("Curso actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _courseDao.Delete(id);
            return Ok("Curso eliminado correctamente");
        }
    }
}