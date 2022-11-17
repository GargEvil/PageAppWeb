using PageAppWeb.DTOs;

namespace PageAppWeb.Services;

public interface ICourseService
{
    Task AddCourse(CourseDTO course);
    Task<List<CourseDTO>> GetAll();
}
