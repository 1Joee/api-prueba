namespace api_prueba.Controllers;
using dao_library;
using entity_library;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TrainerController : ControllerBase
{
    private readonly ILogger<TrainerController> _logger;
    private readonly TrainerDAO _trainerDAO;

    public TrainerController(ILogger<TrainerController> logger, TrainerDAO trainerDAO)
    {
        _logger = logger;
        _trainerDAO = trainerDAO;
    }

    [HttpGet]
    public ActionResult<List<Trainer>> GetAll()
    {
        return Ok(_trainerDAO.GetAllTrainers());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Trainer? trainer = _trainerDAO.GetTrainerById(id);
        if (trainer == null)
        {
            return NotFound();
        }
        return Ok(trainer);
    }

    [HttpPost]
    public IActionResult Create(Trainer trainer)
    {
        Trainer created = _trainerDAO.CreateTrainer(trainer);
        return Created($"/api/Trainer/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Trainer trainer)
    {
        if (_trainerDAO.GetTrainerById(id) == null)
        {
            return NotFound();
        }
        trainer.Id = id;
        _trainerDAO.UpdateTrainer(trainer);
        return Ok(trainer);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool deleted = _trainerDAO.DeleteTrainerById(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
