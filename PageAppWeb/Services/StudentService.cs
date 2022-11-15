using PageApp.Infrastracture.Models;
using PageApp.Infrastracture.Repositories;

namespace PageAppWeb.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<List<Student>> GetAllStudents()
    {
        return await _studentRepository.GetAllStudents();
    }
}
