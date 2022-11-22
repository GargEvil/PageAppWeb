using PageApp.Infrastracture.Models;
using PageAppWeb.DTOs;

namespace PageAppWeb.CustomMapper;

public interface IMapper
{
    Task<StudentDTO> MapToStudentDtoAsync(Student student);
    Task<StudentStatusDTO> MapToStudentStatusDto(int studentStatusId);
    Task<List<StudentDTO>> MapToListStudentDtoAsync(IEnumerable<Student> students);
    Student MapToStudentDomainModel(StudentDTO studentDTO);
    Course MapToCourseDomainModel(CourseDTO courseDTO);
    CourseDTO MapToCourseDTO(Course course);
    List<Student> MapToStudentListDomainModel(List<StudentDTO> studentsDtos);
    Task<List<CourseDTO>> MapToCourseDtoList(IEnumerable<Course> courses);
}