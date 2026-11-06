namespace api_prueba.Controllers;
using dao_library;
using entity_library;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TeamController : ControllerBase
{
    private readonly ILogger<TeamController> _logger;
    private readonly TeamDAO _teamDAO;

    public TeamController(ILogger<TeamController> logger, TeamDAO teamDAO)
    {
        _logger = logger;
        _teamDAO = teamDAO;
    }

    [HttpGet]
    public ActionResult<List<Team>> GetAll()
    {
        return Ok(_teamDAO.GetAllTeams());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Team? team = _teamDAO.GetTeamById(id);
        if (team == null)
        {
            return NotFound();
        }
        return Ok(team);
    }

    [HttpPost]
    public IActionResult Create(Team team)
    {
        Team created = _teamDAO.CreateTeam(team);
        return Created($"/api/Team/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Team team)
    {
        if (_teamDAO.GetTeamById(id) == null)
        {
            return NotFound();
        }
        team.Id = id;
        _teamDAO.UpdateTeam(team);
        return Ok(team);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool deleted = _teamDAO.DeleteTeamById(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
