namespace api_prueba.Controllers;
using dao_library;
using entity_library;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    private readonly StudentDAO _studentDAO;

    public StudentController(ILogger<StudentController> logger, StudentDAO studentDAO)
    {
        _logger = logger;
        _studentDAO = studentDAO;
    }

    [HttpGet]
    public ActionResult<List<Student>> GetAll()
    {
        return Ok(_studentDAO.GetAllStudents());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Student? student = _studentDAO.GetStudentById(id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        Student created = _studentDAO.CreateStudent(student);
        return Created($"/api/Student/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Student student)
    {
        if (_studentDAO.GetStudentById(id) == null)
        {
            return NotFound();
        }
        student.Id = id;
        _studentDAO.UpdateStudent(student);
        return Ok(student);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool deleted = _studentDAO.DeleteStudentById(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
