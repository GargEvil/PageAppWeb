using PageApp.Infrastracture.Models;

namespace PageApp.Infrastracture.Repositories;

public interface IStudentRepository
{
    Task<List<Student>> GetAll();
    Task<Student> GetById(int id);
    Task Add(Student student);
    Task<Student> Update(Student student);
    Task Delete(Student student);
}
