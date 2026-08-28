using System.Collections.Generic;

public class Team
{
    public string Name {get; set;}
    public string Category {get; set;}

    public List<Player> Players {get; set;} = new List<Player>();

    public Team (string name, string category)
    {
        Name = name;
        Category = category;
    }
}