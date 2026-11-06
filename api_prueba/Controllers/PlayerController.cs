namespace api_prueba.Controllers;
using dao_library;
using entity_library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly ILogger<PlayerController> _logger;
    private readonly PlayerDAO _playerDAO;

    public PlayerController(ILogger<PlayerController> logger, PlayerDAO playerDAO)
    {
        _logger = logger;
        _playerDAO = playerDAO;
    }

    [HttpGet]
    public ActionResult<List<Player>> GetAll()
    {
        return Ok(_playerDAO.GetAllPlayers());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Player? player = _playerDAO.GetPlayerById(id);
        if (player == null)
        {
            return NotFound();
        }
        return Ok(player);
    }

    [HttpPost]
    public IActionResult Create(Player player)
    {
        Player created = _playerDAO.CreatePlayer(player);
        return Created($"/api/Player/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Player player)
    {
        if (_playerDAO.GetPlayerById(id) == null)
        {
            return NotFound();
        }
        player.Id = id;
        _playerDAO.UpdatePlayer(player);
        return Ok(player);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool deleted = _playerDAO.DeletePlayerById(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
