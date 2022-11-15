using IdentityModel;
using IdentityServer4.Test;
using System.Security.Claims;

namespace PageWebApp.IdentityServer4.IdentityConfiguration;

public class Users
{
    public static List<TestUser> Get()
    {
        return new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "56892347",
                Username = "pageAppUser",
                Password = "password",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Email, "info@pageapp.com"),
                    new Claim(JwtClaimTypes.Role, "admin"),
                    new Claim(JwtClaimTypes.WebSite, "https://www.page.ba")
                }
            }
        };
    }
}
