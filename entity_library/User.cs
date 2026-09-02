using System.ComponentModel.DataAnnotations;

public class User : Person
{
    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    [MaxLength(100, ErrorMessage = "El email no puede tener más de 100 caracteres.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "El rol es obligatorio.")]
    public RoleType Role { get; set; }
}