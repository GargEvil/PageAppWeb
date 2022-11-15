using IdentityServer4;
using IdentityServer4.Models;

namespace PageWebApp.IdentityServer4.IdentityConfiguration;

public class Clients
{
    public static IEnumerable<Client> Get()
    {
        return new List<Client>
        {
            new Client
            {
                ClientId = "pageAppWeb",
                ClientName = "ASP.NET Web API PageApp",
                ClientSecrets = new List<Secret> {new Secret("pageApp".Sha256())},

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                RedirectUris = new List<string> {"https://google.com"},//Set localhost of Vue.js App
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "role",
                    "pageApp.read",
                    "pageApp.write"
                }
            }
        };
    }
}
