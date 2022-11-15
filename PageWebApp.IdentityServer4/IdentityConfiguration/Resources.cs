using IdentityServer4.Models;

namespace PageWebApp.IdentityServer4.IdentityConfiguration;

public class Resources
{
    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        return new[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResource
            {
                Name = "role",
                UserClaims = new List<string> {"role"}
            }
        };
    }
    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new[]
        {
            new ApiResource
            {
                Name = "pageAppWeb",
                DisplayName = "ASP.NET Web API PageApp",
                Description = "Allow the application to access PageApp on your behalf",
                Scopes = new List<string> { "pageApp.read", "pageApp.write"},
                ApiSecrets = new List<Secret> {new Secret("pageApp".Sha256())},
                UserClaims = new List<string> {"role"}
            }
        };
    }
}
