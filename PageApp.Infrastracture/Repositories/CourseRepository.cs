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
        _context.Add(course);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Course>> GetAll()
    {
        return await _context.Courses.ToListAsync();
    }
}
