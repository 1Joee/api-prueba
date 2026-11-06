namespace dao_library;
using entity_library;

public class StudentDAO
{
    public List<Student> GetAllStudents()
    {
        return MockDatabase.Students;
    }

    public Student? GetStudentById(int id)
    {
        return MockDatabase.Students.FirstOrDefault(x => x.Id == id);
    }

    public Student CreateStudent(Student entity)
    {
        int lastId = MockDatabase.Students.Count == 0 ? 0 : MockDatabase.Students.Max(x => x.Id);
        entity.Id = lastId + 1;
        MockDatabase.Students.Add(entity);
        return entity;
    }

    public bool UpdateStudent(Student entity)
    {
        Student? existing = GetStudentById(entity.Id);
        if (existing == null)
        {
            return false;
        }
        existing.Name = entity.Name;
        existing.Age = entity.Age;
        existing.Dni = entity.Dni;
        existing.File = entity.File;
        return true;
    }

    public bool DeleteStudentById(int id)
    {
        Student? existing = GetStudentById(id);
        if (existing == null)
        {
            return false;
        }
        MockDatabase.Students.Remove(existing);
        return true;
    }
}
