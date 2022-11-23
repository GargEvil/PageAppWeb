using Mapster;
using PageApp.Infrastracture.Abstractions;
using PageApp.Infrastracture.Models;
using PageApp.Infrastracture.Repositories;
using PageAppWeb.CustomMapper;
using PageAppWeb.DTOs;
using PageAppWeb.Exceptions;

namespace PageAppWeb.Services;

internal class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(ICourseRepository courseRepository,
        IStudentRepository studentRepository,
        IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddCourse(CourseDTO course)
    {
        CheckIfStudentsExist(course);
        var courseDb = course.Adapt<Course>();
        _courseRepository.Attach(courseDb);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
    }

    public async Task<List<CourseDTO>> GetAll()
    {
        var courses = _courseRepository.GetAllWithInclude("Student");
        return courses.Adapt<List<CourseDTO>>();
    }

    private void CheckIfStudentsExist(CourseDTO course)
    {
        foreach (var student in course.Students)
        {
            var checkIfExist = _studentRepository.GetAsNoTracking(student.StudentId);

            if (checkIfExist == null)
                throw new StudentNotFoundException(student.StudentId);
        }
    }
}
