namespace PageAppWeb.DTOs;

public class CourseDTO
{
    public CourseDTO()
    {
        Students = new List<StudentDTO>();
    }
    public int CourseId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public virtual List<StudentDTO>? Students { get; set; }
}
