using Mapster;
using PageAppWeb.DTOs;
using System.Reflection;

namespace PageAppWeb.CustomMapper;

public static class MapsterConfiguration
{
    public static void AddMapster(this IServiceCollection services)
    {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        Assembly applicationAssembly = typeof(BaseDTO<,>).Assembly;
        typeAdapterConfig.Scan(applicationAssembly);
    }
}
