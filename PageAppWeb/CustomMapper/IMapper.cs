using PageApp.Infrastracture.Models;
using PageAppWeb.DTOs;

namespace PageAppWeb.CustomMapper;

public interface IMapper
{
    Task<StudentDTO> MapToViewModelAsync(Student student);
    Task<StudentStatusDTO> MapToStudentStatusDto(int studentStatusId);
    Task<List<StudentDTO>> MapToListViewModelAsync(List<Student> students);
    Student MapToDomainModel(StudentDTO studentDTO);

}