public class User : Person
{
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleType Role { get; set; }
}