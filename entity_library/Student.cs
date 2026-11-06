namespace entity_library;

public class Student : Person
{
    private int file = 0;

    public int File
    {
        get { return file; }
        set { file = value; }
    }
}
