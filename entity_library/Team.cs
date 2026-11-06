using System.ComponentModel.DataAnnotations;

namespace entity_library;

public class Team
{
    private int id = 0;
    private string name = "";
    private string category = "";
    private List<Player> players = new List<Player>();

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

    [Required]
    public string Category
    {
        get { return category; }
        set { category = value; }
    }

    public List<Player> Players
    {
        get { return players; }
        set { players = value; }
    }
}
