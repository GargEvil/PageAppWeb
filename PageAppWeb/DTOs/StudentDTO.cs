using PageApp.Infrastracture.Models;

namespace PageAppWeb.DTOs;

public class StudentDTO : BaseDTO<StudentDTO, Student>
{
    public int StudentId { get; set; }
    public string IndexNumber { get; set; }
    public string FullName { get; set; }
    public int Year { get; set; }
    public string StudentStatus { get; set; }

    public override void AddCustomMappings()
    {
        SetCustomMappingsInverse()
            .Map(dest => dest.FullName, src => $"{src.Name} {src.Surname}")
            .Map(dest => dest.StudentStatus, src => MapStudentStatus(src.StudentStatusId));

    }

    public static string MapStudentStatus(int studentStatusId)
    {
        return studentStatusId == 1 ?
            StudentStatusEnum.Redovan.ToString() :
            StudentStatusEnum.Vanredan.ToString();
    }

    enum StudentStatusEnum
    {
        Redovan = 1,
        Vanredan
    }
}
