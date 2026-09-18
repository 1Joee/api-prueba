namespace api_prueba.Controllers;
using api_prueba.DTOs;
using api_prueba.Security;
using dao_library;
using entity_library;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly UserDAO _userDAO;
    private readonly JwtService _jwtService;

    public UserController(ILogger<UserController> logger, UserDAO userDAO, JwtService jwtService)
    {
        _logger = logger;
        _userDAO = userDAO;
        _jwtService = jwtService;
    }

    [HttpPost]
    public ActionResult<UserResponseDTO> CreateUser(User user)
    {
        if (_userDAO.GetUserByEmail(user.Email) != null)
        {
            return BadRequest("Ya existe un usuario registrado con ese email.");
        }

        user.Password = PasswordHasher.HashPassword(user.Password);
        User createdUser = _userDAO.SaveUser(user);

        return Created($"/User/{createdUser.Id}", ToResponseDTO(createdUser));
    }

    [HttpPost("login")]
    public ActionResult<LoginResponseDTO> Login(LoginDTO login)
    {
        User? user = _userDAO.GetUserByEmail(login.Email);
        if (user == null || !PasswordHasher.VerifyPassword(login.Password, user.Password))
        {
            return Unauthorized("Email o contraseña incorrectos.");
        }

        string token = _jwtService.GenerateToken(user);

        LoginResponseDTO response = new LoginResponseDTO
        {
            Token = token,
            User = ToResponseDTO(user)
        };

        return Ok(response);
    }

    private static UserResponseDTO ToResponseDTO(User user)
    {
        return new UserResponseDTO
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role.ToString()
        };
    }
}
