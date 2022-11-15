using PageAppWeb.Services;

namespace PageAppWeb;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();

        return services;
    }
}
