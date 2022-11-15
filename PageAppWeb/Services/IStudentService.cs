using PageApp.Infrastracture.Models;

namespace PageAppWeb.Services;

public interface IStudentService
{
    Task<List<Student>> GetAllStudents();
}
