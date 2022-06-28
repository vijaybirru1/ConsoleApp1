using Microsoft.Graph;
using System;
using Azure.Identity;
using System.Collections.Generic;
//using System.IdentityModel.Tokens;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace ConsoleApp1
{
    class AzureAuthProvider: IAuthenticationProvider
    {
        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            try
            {

                var tenantId = "6764eba9-7437-462d-85a2-06aa757d64f6";
                var clientId = "d1a0effd-b6bf-4744-ab03-cbc70cbddf71";
                var clientSecret = "9j08Q~rhU5tylFVkNGDdtxD.QXDu4aHxY5hPPbbS";

                //var tenantId = "2199bfba-a409-4f13-b0c4-18b45933d88d";
                //var clientId = "a1ff4abd-76b0-41af-a79b-dfff970b7b15";
                //var clientSecret = "2199bfba-a409-4f13-b0c4-18b45933d88d";

                // Values from app registration




                string resource = "https://graph.microsoft.com";
                //reading tenant id from JSON file
                string authority = "https://login.windows.net/" + tenantId;

                AuthenticationContext auth = new AuthenticationContext(authority, false);

                ClientCredential clientCredential = new ClientCredential(clientId, clientSecret);

                var authResult = auth.AcquireTokenAsync(resource, clientCredential).Result;

                var accessToken = authResult.AccessToken;
                request.Headers.Add("Authorization", "Bearer " + accessToken);
                request.Headers.Add("Prefer", "outlook.body-content-type='text'");
            }
            catch (Exception ex)
            {
                //ToDo : Proper exception handling
                Console.Write("Exception Message: " + ex.Message);
                Console.Write("\n\nStack Trace: " + ex.StackTrace);
            }
        }
    }
}
