using PageWebApp.IdentityServer4.IdentityConfiguration;

namespace PageWebApp.IdentityServer4.ServiceConfiguration;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddIdentityServer()
        .AddInMemoryClients(Clients.Get())
        .AddInMemoryIdentityResources(Resources.GetIdentityResources())
        .AddInMemoryApiResources(Resources.GetApiResources())
        .AddInMemoryApiScopes(Scopes.GetApiScopes())
        .AddTestUsers(Users.Get())
        .AddDeveloperSigningCredential();

        services.AddControllersWithViews();

        return services;
    }
}
