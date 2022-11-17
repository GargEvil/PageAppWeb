using PageApp.Infrastracture.Models;

namespace PageApp.Infrastracture.Repositories;
public interface IStudentStatusRepository
{
    Task<StudentStatus> GetStudentStatusById(int studentStatusId);
}
