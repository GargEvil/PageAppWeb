using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PageApp.Infrastracture.Abstractions;
using PageApp.Infrastracture.Repositories;

namespace PageApp.Infrastracture;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("PageAppDb");

        services.AddDbContext<PageAppDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IStudentStatusRepository, StudentStatusRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<PageAppDbContext>());

        return services;
    }
}
