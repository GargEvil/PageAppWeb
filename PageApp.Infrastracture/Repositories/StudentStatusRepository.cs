using Microsoft.EntityFrameworkCore;
using PageApp.Infrastracture.Models;

namespace PageApp.Infrastracture.Repositories;

public class StudentStatusRepository : IStudentStatusRepository
{
    private readonly PageAppDbContext _dbContext;

    public StudentStatusRepository(PageAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<StudentStatus> GetStudentStatusById(int studentStatusId)
    {
        return await _dbContext.StudentStatuses.FirstOrDefaultAsync(e => e.StudentStatusId == studentStatusId);
    }
}
