using System.Collections.Generic;

namespace entity_library
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Activity> Activities { get; set; } = new List<Activity>();
    }
}