namespace PageApp.Infrastracture.Models;

public class Course
{
    public Course()
    {
        Student = new HashSet<Student>();
    }

    public int CourseId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public virtual ICollection<Student> Student { get; set; }
}