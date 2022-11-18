using PageApp.Infrastracture.Repositories;
using PageAppWeb.CustomMapper;
using PageAppWeb.DTOs;
using PageAppWeb.Exceptions;

namespace PageAppWeb.Services;

internal class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public CourseService(ICourseRepository courseRepository, IMapper mapper, IStudentRepository studentRepository)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
        _studentRepository = studentRepository;
    }

    public async Task AddCourse(CourseDTO course)
    {
        await CheckIfStudentsExist(course);
        await _courseRepository.AddCourse(_mapper.MapToCourseDomainModel(course));
    }

    public async Task<List<CourseDTO>> GetAll()
    {
        return await _mapper.MapToCourseDtoList(await _courseRepository.GetAll());
    }

    private async Task CheckIfStudentsExist(CourseDTO course)
    {
        foreach (var student in course.Students)
        {
            var checkIfExist = await _studentRepository.GetById(student.StudentId);

            if (checkIfExist == null)
                throw new StudentNotFoundException(student.StudentId);
        }
    }
}
