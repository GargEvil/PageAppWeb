using PageApp.Infrastracture.Models;

namespace PageAppWeb.DTOs;

public class CourseDTO : BaseDTO<CourseDTO, Course>
{
    public CourseDTO()
    {
        Students = new List<StudentDTO>();
    }

    public int CourseId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public List<StudentDTO>? Students { get; set; }

    public override void AddCustomMappings()
    {
        SetCustomMappingsInverse()
            .Map(dest => dest.Students, src => src.Student);
    }
}
