namespace dao_library;
using entity_library;

public static class MockDatabase
{
    public static List<Player> Players { get; set; } = new();
    public static List<Team> Teams { get; set; } = new();
    public static List<Trainer> Trainers { get; set; } = new();
    public static List<Student> Students { get; set; } = new()
    {
        new Student { Id = 1, File = 101, Name = "Lucas Gomez", Age = 21, Dni = "40123456" },
        new Student { Id = 2, File = 102, Name = "Sofia Perez", Age = 22, Dni = "41987654" }
    };
    public static List<Course> Courses { get; set; } = new()
    {
        new Course { Id = 1, Name = "Programación III" }
    };
}
