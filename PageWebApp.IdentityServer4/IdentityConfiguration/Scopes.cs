using IdentityServer4.Models;

namespace PageWebApp.IdentityServer4.IdentityConfiguration;

public class Scopes
{
    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return new[]
        {
            new ApiScope("pageApp.read", "Read Access to PageApp API"),
            new ApiScope("pageApp.write", "Write Access to PageApp API"),
        };
    }
}
