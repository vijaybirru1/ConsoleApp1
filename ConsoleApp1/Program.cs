using Azure.Identity;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tenantId = "6764eba9-7437-462d-85a2-06aa757d64f6";

            // Values from app registration
            var clientId = "d1a0effd-b6bf-4744-ab03-cbc70cbddf71";
            var clientSecret = "9j08Q~rhU5tylFVkNGDdtxD.QXDu4aHxY5hPPbbS";

            // using Azure.Identity;
            var options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            // https://docs.microsoft.com/dotnet/api/azure.identity.clientsecretcredential
            var clientSecretCredential = new ClientSecretCredential(
                tenantId, clientId, clientSecret, options);


			GraphServiceClient graphClient = new GraphServiceClient(clientSecretCredential);
			

			//await graphClient.Me
			//	.SendMail(message, null)
			//	.Request()
			//	.PostAsync();
			var message = new Message
			{
				Subject = "This is form graphAPI",
				Body = new ItemBody
				{
					ContentType = BodyType.Html,
					Content = "Hello world!"
				},
				ToRecipients = new List<Recipient>()
	{
		new Recipient { EmailAddress = new EmailAddress { Address = "AnushaReddy@mycom12.onmicrosoft.com" }}
	}
			};

			// Send mail as the given user. 
			graphClient
				.Users["MyGraphUser@outlook.com"]
				.SendMail(message, true)
				.Request()
				.PostAsync().Wait();
		}
    }
}
