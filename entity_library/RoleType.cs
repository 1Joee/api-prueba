// 1. Primero definimos el Enum tal como está en la diapositiva
public enum RoleType
{
    User,
    Admin
}

// 2. Creamos la entidad User heredando de Person
public class User : Person
{
    // Propiedades específicas de la cuenta (que no tiene una Persona común)
    public string Email { get; set; }
    public string Password { get; set; }

    // La relación con el rol que marca el diagrama
    public RoleType Role { get; set; }
}