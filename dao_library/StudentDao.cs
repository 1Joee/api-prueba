using entity_library;
using System.Collections.Generic;
using System.Linq;

namespace dao_library
{
    public class StudentDao : IDao<Student>
    {
        private static List<Student> _students = new List<Student>
        {
            new Student { File = 101, Name = "Lucas Gomez", Age = 21, Dni = "40123456" },
            new Student { File = 102, Name = "Sofia Perez", Age = 22, Dni = "41987654" }
        };

        public List<Student> GetAll() => _students;

        public Student GetById(int id) => _students.FirstOrDefault(s => s.File == id)!;

        public void Add(Student entity) => _students.Add(entity);

        public void Update(Student entity)
        {
            var existing = GetById(entity.File);
            if (existing != null)
            {
                existing.Name = entity.Name;
                existing.Age = entity.Age;
                existing.Dni = entity.Dni;
            }
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null) _students.Remove(existing);
        }
    }
}