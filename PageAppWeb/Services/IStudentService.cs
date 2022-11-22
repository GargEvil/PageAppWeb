using PageAppWeb.DTOs;

namespace PageAppWeb.Services;

public interface IStudentService
{
    Task<List<StudentDTO>> GetAllStudents();
    Task AddStudent(StudentDTO student);
    Task UpdateStudent(int id, StudentDTO student);
    Task DeleteStudent(int id);
    Task<List<StudentDTO>> GetStudentsByCourseId(int courseId);
}
