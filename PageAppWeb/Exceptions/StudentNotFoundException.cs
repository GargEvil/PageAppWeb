using PageApp.Infrastracture.ExceptionHandling;

namespace PageAppWeb.Exceptions;

public class StudentNotFoundException : NotFoundException
{
    public StudentNotFoundException(int id) : base($"Student with given id {id} is not found!")
    {
    }
}
