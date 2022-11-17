using PageAppWeb.CustomMapper;
using PageAppWeb.Services;

namespace PageAppWeb;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddAuthentication("Bearer")
        .AddIdentityServerAuthentication("Bearer", options =>
        {
            options.ApiName = "pageAppWeb";
            options.Authority = "https://localhost:7138"; //<- Add your identity server localhost if changed
        });

        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IMapper, Mapper>();

        return services;
    }
}
