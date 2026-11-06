namespace api_prueba.Controllers;
using dao_library;
using entity_library;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ILogger<CourseController> _logger;
    private readonly CourseDAO _courseDAO;

    public CourseController(ILogger<CourseController> logger, CourseDAO courseDAO)
    {
        _logger = logger;
        _courseDAO = courseDAO;
    }

    [HttpGet]
    public ActionResult<List<Course>> GetAll()
    {
        return Ok(_courseDAO.GetAllCourses());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Course? course = _courseDAO.GetCourseById(id);
        if (course == null)
        {
            return NotFound();
        }
        return Ok(course);
    }

    [HttpPost]
    public IActionResult Create(Course course)
    {
        Course created = _courseDAO.CreateCourse(course);
        return Created($"/api/Course/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Course course)
    {
        if (_courseDAO.GetCourseById(id) == null)
        {
            return NotFound();
        }
        course.Id = id;
        _courseDAO.UpdateCourse(course);
        return Ok(course);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool deleted = _courseDAO.DeleteCourseById(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
