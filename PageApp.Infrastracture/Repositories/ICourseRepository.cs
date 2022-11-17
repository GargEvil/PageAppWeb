using PageApp.Infrastracture.Models;

namespace PageApp.Infrastracture.Repositories;

public interface ICourseRepository
{
    Task AddCourse(Course course);
    Task<List<Course>> GetAll();
}
