namespace PageApp.Infrastracture.Models;

public class Course
{
    public Course()
    {
        Students = new HashSet<Student>();
    }

    public int CourseId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public virtual ICollection<Student> Students { get; set; }
}