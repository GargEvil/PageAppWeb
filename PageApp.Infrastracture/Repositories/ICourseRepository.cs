using PageApp.Infrastracture.Abstractions;
using PageApp.Infrastracture.Models;

namespace PageApp.Infrastracture.Repositories;

public interface ICourseRepository : IRepository<Course>
{
    Course GetByIdWithInclude(int id, string include);
    List<Course> GetAllWithInclude(string include);
    void Attach(Course course);
}
