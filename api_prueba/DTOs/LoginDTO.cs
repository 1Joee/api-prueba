using System.ComponentModel.DataAnnotations;

namespace api_prueba.DTOs;

public class LoginDTO
{
    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    public string Password { get; set; }
}
