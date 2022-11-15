using Microsoft.EntityFrameworkCore;
using PageApp.Infrastracture.Models;

namespace PageApp.Infrastracture.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly PageAppDbContext _context;

    public StudentRepository(PageAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> GetAllStudents()
    {
        return await _context.Students.ToListAsync();
    }
}
