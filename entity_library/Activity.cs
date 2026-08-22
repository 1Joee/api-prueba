using System;

namespace entity_library
{
    public class Activity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TypeActivity Type { get; set; }
    }
}