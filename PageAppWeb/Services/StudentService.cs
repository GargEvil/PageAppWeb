using Mapster;
using PageApp.Infrastracture.Abstractions;
using PageApp.Infrastracture.Models;
using PageApp.Infrastracture.Repositories;
using PageAppWeb.CustomMapper;
using PageAppWeb.DTOs;
using PageAppWeb.Exceptions;

namespace PageAppWeb.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public StudentService(IStudentRepository studentRepository,
        ICourseRepository courseRepository,
        IUnitOfWork unitOfWork)
    {
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddStudent(StudentDTO student)
    {
        _studentRepository.Add(student.ToEntity());
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
    }

    public async Task DeleteStudent(int id)
    {
        var student = _studentRepository.Get(id);

        if (student == null)
            throw new StudentNotFoundException(id);

        _studentRepository.Remove(student);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
    }

    public async Task<List<StudentDTO>> GetAllStudents()
    {
        var students = _studentRepository.GetAll();
        return students.Adapt<List<StudentDTO>>();
    }

    public async Task<List<StudentDTO>> GetStudentsByCourseId(int courseId)
    {
        var course = _courseRepository.GetByIdWithInclude(courseId, "Student");

        return course.Student.Adapt<List<StudentDTO>>();
    }

    public async Task UpdateStudent(int id, StudentDTO student)
    {
        var studentToBeUpdated = _studentRepository.Get(id);

        if (studentToBeUpdated == null)
            throw new StudentNotFoundException(id);

        studentToBeUpdated = student.Adapt<Student>();
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
    }

}
