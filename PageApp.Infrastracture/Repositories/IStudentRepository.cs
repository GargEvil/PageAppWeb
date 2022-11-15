using PageApp.Infrastracture.Models;

namespace PageApp.Infrastracture.Repositories;

public interface IStudentRepository
{
    Task<List<Student>> GetAllStudents();
}
