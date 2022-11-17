using PageApp.Infrastracture.Repositories;
using PageAppWeb.CustomMapper;
using PageAppWeb.DTOs;

namespace PageAppWeb.Services;

internal class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public CourseService(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task AddCourse(CourseDTO course)
    {
        await _courseRepository.AddCourse(_mapper.MapToCourseDomainModel(course));
    }

    public async Task<List<CourseDTO>> GetAll()
    {
        return await _mapper.MapToCourseDtoList(await _courseRepository.GetAll());
    }
}
