using PageApp.Infrastracture.Repositories;
using PageAppWeb.CustomMapper;
using PageAppWeb.DTOs;
using PageAppWeb.Exceptions;

namespace PageAppWeb.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository,
        IMapper mapper,
        ICourseRepository courseRepository)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
        _courseRepository = courseRepository;
    }

    public async Task AddStudent(StudentDTO student)
    {
        await _studentRepository.Add(_mapper.MapToStudentDomainModel(student));
    }

    public async Task DeleteStudent(int id)
    {
        var student = await _studentRepository.GetById(id);

        if (student == null)
            throw new StudentNotFoundException(id);

        await _studentRepository.Delete(student);
    }

    public async Task<List<StudentDTO>> GetAllStudents()
    {
        var students = await _studentRepository.GetAll();

        return await _mapper.MapToListStudentDtoAsync(students);
    }

    public async Task<List<StudentDTO>> GetStudentsByCourseId(int courseId)
    {
        var course = await _courseRepository.GetById(courseId);

        return await _mapper.MapToListStudentDtoAsync(course.Student);
    }

    public async Task<StudentDTO> UpdateStudent(int id, StudentDTO student)
    {
        var studentToBeUpdated = await _studentRepository.GetById(id);

        if (studentToBeUpdated == null)
            throw new StudentNotFoundException(id);

        studentToBeUpdated.Name = student.Name;
        studentToBeUpdated.Surname = student.Surname;
        studentToBeUpdated.IndexNumber = student.IndexNumber;
        studentToBeUpdated.StudentStatusId = student.StudentStatusId;
        studentToBeUpdated.Year = student.Year;

        var updatedStudent = await _studentRepository.Update(studentToBeUpdated);
        return await _mapper.MapToStudentDtoAsync(updatedStudent);
    }

}
