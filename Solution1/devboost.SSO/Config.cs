using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.SSO
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "devboostSSO",
                    DisplayName = "devboost SSO",
                    Scopes = { "Business" }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {

            return new List<Client>
            {

                //Client-Credential GrantType
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "Business" },
                    Enabled = true,
                    AllowOfflineAccess = true
                }


            };
        }

        public static IEnumerable<ApiScope> GetScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("Business", "devboost SSO")
            };
        }



    }
}
