using PageApp.Infrastracture.Abstractions;
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
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository,
        IMapper mapper,
        ICourseRepository courseRepository,
        IUnitOfWork unitOfWork)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddStudent(StudentDTO student)
    {
        _studentRepository.Add(_mapper.MapToStudentDomainModel(student));
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

        return await _mapper.MapToListStudentDtoAsync(students);
    }

    public async Task<List<StudentDTO>> GetStudentsByCourseId(int courseId)
    {
        var course = _courseRepository.GetByIdWithInclude(courseId, "Student");

        return await _mapper.MapToListStudentDtoAsync(course.Student);
    }

    public async Task UpdateStudent(int id, StudentDTO student)
    {
        var studentToBeUpdated = _studentRepository.Get(id);

        if (studentToBeUpdated == null)
            throw new StudentNotFoundException(id);

        studentToBeUpdated.Name = student.Name;
        studentToBeUpdated.Surname = student.Surname;
        studentToBeUpdated.IndexNumber = student.IndexNumber;
        studentToBeUpdated.StudentStatusId = student.StudentStatusId;
        studentToBeUpdated.Year = student.Year;

        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
    }

}
