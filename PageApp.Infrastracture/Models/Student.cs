namespace PageApp.Infrastracture.Models;

public class Student
{
    public Student()
    {
        Course = new HashSet<Course>();
    }

    public int StudentId { get; set; }
    public string IndexNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int Year { get; set; }
    public int StudentStatusId { get; set; }
    public virtual ICollection<Course> Course { get; set; }
}