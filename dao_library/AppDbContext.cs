using Microsoft.EntityFrameworkCore;
using entity_library; 

namespace dao_library; 

public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions options) : base(options) { } 
    public DbSet<User> Users { get; set; } 
    
    // (Si tenés otras entidades como Activity, Course, etc., las agregás acá abajo de la misma forma)
    // public DbSet<Activity> Activities { get; set; }
}