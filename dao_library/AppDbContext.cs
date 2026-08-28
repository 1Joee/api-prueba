using Microsoft.EntityFrameworkCore;
using entity_library;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions options) : base(options) { } // No tiene que ir nada dentro de las llaves

    
    public DbSet<Entity> Entities { get; set; } // Acá colocaremos la entidad que queremos guardar en la base de datos (se debe hacer con c/u de ellas)
}