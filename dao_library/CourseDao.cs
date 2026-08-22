using entity_library;
using System.Collections.Generic;
using System.Linq;

namespace dao_library
{
    public class CourseDao : IDao<Course>
    {
        private static List<Course> _courses = new List<Course>
        {
            new Course { Id = 1, Name = "Programación III" }
        };

        public List<Course> GetAll() => _courses;

        public Course GetById(int id) => _courses.FirstOrDefault(c => c.Id == id)!;

        public void Add(Course entity) => _courses.Add(entity);

        public void Update(Course entity)
        {
            var existing = GetById(entity.Id);
            if (existing != null)
            {
                existing.Name = entity.Name;
                existing.Students = entity.Students;
                existing.Activities = entity.Activities;
            }
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null) _courses.Remove(existing);
        }
    }
}