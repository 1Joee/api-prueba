namespace dao_library;
using entity_library;
using Microsoft.EntityFrameworkCore;

public class UserDAO
{
    private readonly AppDbContext _context;

    public UserDAO(AppDbContext context)
    {
        _context = context;
    }

    public User? GetUserByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }

    public User? GetUserById(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public User SaveUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }
}
