using Dapper;
using Microsoft.EntityFrameworkCore;
using PageApp.Infrastracture.Abstractions;
using PageApp.Infrastracture.Models;
using System.Data;

namespace PageApp.Infrastracture.Repositories;

internal class StudentRepository : Repository<Student>, IStudentRepository
{
    private readonly PageAppDbContext _context;

    public StudentRepository(PageAppDbContext context) : base(context)
    {
        _context = context;
    }

    public Student GetAsNoTracking(int id)
    {
        return _context.Students.AsNoTracking().FirstOrDefault(e => e.StudentId == id);
    }
}
