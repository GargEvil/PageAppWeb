using PageApp.Infrastracture.Abstractions;
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
    private readonly IMapper _mapper;

    public CourseService(ICourseRepository courseRepository, IMapper mapper, IStudentRepository studentRepository, IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddCourse(CourseDTO course)
    {
        CheckIfStudentsExist(course);
        _courseRepository.Attach(_mapper.MapToCourseDomainModel(course));
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
    }

    public async Task<List<CourseDTO>> GetAll()
    {
        return await _mapper.MapToCourseDtoList(_courseRepository.GetAll());
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
