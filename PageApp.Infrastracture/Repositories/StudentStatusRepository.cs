using Microsoft.EntityFrameworkCore;
using PageApp.Infrastracture.Abstractions;
using PageApp.Infrastracture.Models;

namespace PageApp.Infrastracture.Repositories;

internal class StudentStatusRepository : Repository<StudentStatus>, IStudentStatusRepository
{
    public StudentStatusRepository(PageAppDbContext dbContext) : base(dbContext)
    {
    }
}
