namespace PageAppWeb.DTOs;

public class StudentDTO
{
    public int StudentId { get; set; }
    public string IndexNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Year { get; set; }
    public int StudentStatusId { get; set; }
    public StudentStatusDTO StudentStatus { get; set; }
}
