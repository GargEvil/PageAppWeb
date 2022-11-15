using PageApp.Infrastracture.Models;

namespace PageAppWeb.Services;

public interface IStudentService
{
    Task<List<Student>> GetAllStudents();
    Task AddStudent(Student student);
    Task<Student> UpdateStudent(int id, Student student);
    Task DeleteStudent(int id);
}
