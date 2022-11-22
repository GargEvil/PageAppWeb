using PageApp.Infrastracture.Abstractions;
using PageApp.Infrastracture.Models;

namespace PageApp.Infrastracture.Repositories;

public interface IStudentRepository : IRepository<Student>
{
    Student GetAsNoTracking(int id);
}