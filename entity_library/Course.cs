using System.ComponentModel.DataAnnotations;

namespace entity_library;

public class Course
{
    private int id = 0;
    private string name = "";
    private List<Student> students = new List<Student>();
    private List<Activity> activities = new List<Activity>();

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public List<Student> Students
    {
        get { return students; }
        set { students = value; }
    }

    public List<Activity> Activities
    {
        get { return activities; }
        set { activities = value; }
    }
}
