namespace dao_library;
using entity_library;

public class CourseDAO
{
    public List<Course> GetAllCourses()
    {
        return MockDatabase.Courses;
    }

    public Course? GetCourseById(int id)
    {
        return MockDatabase.Courses.FirstOrDefault(x => x.Id == id);
    }

    public Course CreateCourse(Course entity)
    {
        int lastId = MockDatabase.Courses.Count == 0 ? 0 : MockDatabase.Courses.Max(x => x.Id);
        entity.Id = lastId + 1;
        MockDatabase.Courses.Add(entity);
        return entity;
    }

    public bool UpdateCourse(Course entity)
    {
        Course? existing = GetCourseById(entity.Id);
        if (existing == null)
        {
            return false;
        }
        existing.Name = entity.Name;
        existing.Students = entity.Students;
        existing.Activities = entity.Activities;
        return true;
    }

    public bool DeleteCourseById(int id)
    {
        Course? existing = GetCourseById(id);
        if (existing == null)
        {
            return false;
        }
        MockDatabase.Courses.Remove(existing);
        return true;
    }
}
