using PageApp.Infrastracture.Models;
using PageApp.Infrastracture.Repositories;
using PageAppWeb.DTOs;

namespace PageAppWeb.CustomMapper;

public class Mapper : IMapper
{
    private readonly IStudentStatusRepository _studentStatusRepository;

    public Mapper(IStudentStatusRepository studentStatusRepository)
    {
        _studentStatusRepository = studentStatusRepository;
    }

    public async Task<StudentDTO> MapToStudentDtoAsync(Student student)
    {
        return new StudentDTO
        {
            StudentId = student.StudentId,
            Name = student.Name,
            Surname = student.Surname,
            Year = student.Year,
            IndexNumber = student.IndexNumber,
            StudentStatusId = student.StudentStatusId,
            StudentStatus = await MapToStudentStatusDto(student.StudentStatusId)
        };
    }

    public async Task<StudentStatusDTO> MapToStudentStatusDto(int studentStatusId)
    {
        var status = await _studentStatusRepository.GetStudentStatusById(studentStatusId);
        return new StudentStatusDTO
        {
            StudentStatusId = status.StudentStatusId,
            StatusName = status.StatusName
        };
    }

    public async Task<List<StudentDTO>> MapToListStudentDtoAsync(ICollection<Student> students)
    {
        var studentDtos = new List<StudentDTO>();

        foreach (var student in students)
        {
            studentDtos.Add(new StudentDTO
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Surname = student.Surname,
                Year = student.Year,
                IndexNumber = student.IndexNumber,
                StudentStatusId = student.StudentStatusId,
                StudentStatus = await MapToStudentStatusDto(student.StudentStatusId)
            });
        }

        return studentDtos;
    }

    public Student MapToStudentDomainModel(StudentDTO studentDTO)
    {
        return new Student
        {
            StudentStatusId = studentDTO.StudentStatusId,
            Name = studentDTO.Name,
            Year = studentDTO.Year,
            Surname = studentDTO.Surname,
            IndexNumber = studentDTO.IndexNumber
        };
    }

    public Course MapToCourseDomainModel(CourseDTO courseDTO)
    {
        return new Course
        {
            CourseId = courseDTO.CourseId,
            CourseName = courseDTO.CourseName,
            Students = MapToStudentListDomainModel(courseDTO.Students)
        };
    }

    public List<Student> MapToStudentListDomainModel(List<StudentDTO> studentsDtos)
    {
        var students = new List<Student>();

        foreach (var studentDto in studentsDtos)
        {
            students.Add(new Student
            {
                StudentStatusId = studentDto.StudentStatusId,
                Name = studentDto.Name,
                Year = studentDto.Year,
                Surname = studentDto.Surname,
                IndexNumber = studentDto.IndexNumber
            });
        }
        return students;
    }

    public CourseDTO MapToCourseDTO(Course course)
    {
        return new CourseDTO
        {
            CourseId = course.CourseId,
            CourseName = course.CourseName
        };
    }

    public async Task<List<CourseDTO>> MapToCourseDtoList(List<Course> courses)
    {
        var courseDTOs = new List<CourseDTO>();

        foreach (var course in courses)
        {
            courseDTOs.Add(new CourseDTO
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                Students = await MapToListStudentDtoAsync(course.Students)
            });
        }

        return courseDTOs;
    }
}
