using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Andreitoledo.GeekShopping.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Client = "Client";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        // Define um APIScopes
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("geek_shopping", "GeekShopping Server"),
                new ApiScope(name: "read", "Read data."),
                new ApiScope(name: "write", "Write data."),
                new ApiScope(name: "delete", "Delete data."),
            };

        // Um Client é um componente de software que solicita um token ao identityServer
        // Assim, ele pode identificar um usuário e permitir ou negar o acesso a um recurso.

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                // Client Genérico
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("my_super_secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read", "write", "profile" }
                },

                // Client Específico
                new Client
                {
                    ClientId = "geek_shopping",
                    ClientSecrets = { new Secret("my_super_secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"https://localhost:44319/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:44319/signout-callback-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "geek_shopping"
                    }
                }
            };

    }
}
