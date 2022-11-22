using Microsoft.EntityFrameworkCore;
using PageApp.Infrastracture.Abstractions;
using PageApp.Infrastracture.Models;

namespace PageApp.Infrastracture.Repositories;
internal class CourseRepository : Repository<Course>, ICourseRepository
{
    private readonly PageAppDbContext _dbContext;
    public CourseRepository(PageAppDbContext context) : base(context)
    {
        _dbContext = context;
    }

    public void Attach(Course course)
    {
        _dbContext.Courses.Attach(course);
    }

    public Course GetByIdWithInclude(int id, string include)
    {
        return _dbContext.Courses.Include(include).Where(e => e.CourseId == id).FirstOrDefault();
    }
}
