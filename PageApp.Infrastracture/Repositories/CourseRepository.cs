using Microsoft.EntityFrameworkCore;
using PageApp.Infrastracture.Models;

namespace PageApp.Infrastracture.Repositories;
internal class CourseRepository : ICourseRepository
{
    private readonly PageAppDbContext _context;

    public CourseRepository(PageAppDbContext context)
    {
        _context = context;
    }

    public async Task AddCourse(Course course)
    {

        _context.Courses.Add(course);
        _context.SaveChanges();
    }

    public async Task<List<Course>> GetAll()
    {
        return await _context.Courses.Include(e => e.Student).ToListAsync();
    }

    public async Task<Course> GetById(int id)
    {
        return await _context.Courses.FirstOrDefaultAsync(e => e.CourseId == id);
    }
}
