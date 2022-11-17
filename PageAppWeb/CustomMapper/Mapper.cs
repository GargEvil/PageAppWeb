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

    public async Task<StudentDTO> MapToViewModelAsync(Student student)
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

    public async Task<List<StudentDTO>> MapToListViewModelAsync(List<Student> students)
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

    public Student MapToDomainModel(StudentDTO studentDTO)
    {
        return new Student
        {
            StudentId = studentDTO.StudentId,
            StudentStatusId = studentDTO.StudentStatusId,
            Name = studentDTO.Name,
            Year = studentDTO.Year,
            Surname = studentDTO.Surname,
            IndexNumber = studentDTO.IndexNumber
        };
    }
}
