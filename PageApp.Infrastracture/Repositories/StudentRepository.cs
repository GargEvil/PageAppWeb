using Dapper;
using Microsoft.EntityFrameworkCore;
using PageApp.Infrastracture.Models;
using System.Data;
using System.Linq;

namespace PageApp.Infrastracture.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly PageAppDbContext _context;

    public StudentRepository(PageAppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Student student)
    {
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Student>> GetAll()
    {
        using (IDbConnection connection = _context.Database.GetDbConnection())
        {
            connection.Open();

            var record = await connection.QueryMultipleAsync("GetAllStudentsSP", commandType: CommandType.StoredProcedure);

            return record.Read<Student>().ToList();

        }
    }

    public async Task<Student> GetById(int id)
    {
        return await _context.Students.FirstOrDefaultAsync(e => e.StudentId == id);
    }

    public async Task<Student> Update(Student student)
    {
        _context.Entry(student).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return student;
    }
}
