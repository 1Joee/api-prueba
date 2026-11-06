using System.ComponentModel.DataAnnotations;

namespace entity_library;

public class Activity
{
    private int id = 0;
    private string title = "";
    private string? description;
    private DateTime date = DateTime.Now;
    private TypeActivity type = TypeActivity.Obligatoria;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    [StringLength(500)]
    public string? Description
    {
        get { return description; }
        set { description = value; }
    }

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    public TypeActivity Type
    {
        get { return type; }
        set { type = value; }
    }
}
