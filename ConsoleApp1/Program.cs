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
        static async Task Main(string[] args)
        {


			AzureAuthProvider authProvider = new AzureAuthProvider();
			GraphServiceClient _graphClient = new GraphServiceClient(authProvider);
			//var message = new Microsoft.Graph.Message
			//{
			//	Subject = "Subject",
			//	Body = new ItemBody
			//	{
			//		ContentType = Microsoft.Graph.BodyType.Html,
			//		Content = "Test"
			//	},
			//	ToRecipients = new List<Recipient>()
			//		{
			//		new Recipient
			//		{

			//			EmailAddress = new Microsoft.Graph.EmailAddress
			//			{
			//				Address = "MyGraphUser@outlook.com"
			//			}
			//		}
			//		},
			//	//HasAttachments = true,
			//	//Attachments = attachments
			//};

			var inboxMessages = await _graphClient.Users["Paywise@indot.in.gov"]
					.MailFolders["inbox"]
					.Messages
					.Request()
					.GetAsync();

			if(inboxMessages.Count > 0)
            {
                foreach (var mailMsg in inboxMessages)
                {
					Console.WriteLine("Mail Subject : " + mailMsg.Subject);
					Console.WriteLine("Mail Body : " + mailMsg.Body.Content);
				}
				Console.ReadLine();
            }
					//.Wait(8000);
			//           var tenantId = "6764eba9-7437-462d-85a2-06aa757d64f6";

			//           // Values from app registration
			//           var clientId = "d1a0effd-b6bf-4744-ab03-cbc70cbddf71";
			//           var clientSecret = "9j08Q~rhU5tylFVkNGDdtxD.QXDu4aHxY5hPPbbS";

			//           // using Azure.Identity;
			//           var options = new TokenCredentialOptions
			//           {
			//               AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
			//           };



			//           // https://docs.microsoft.com/dotnet/api/azure.identity.clientsecretcredential
			//           var clientSecretCredential = new ClientSecretCredential(
			//               tenantId, clientId, clientSecret, options);


			//		GraphServiceClient graphClient = new GraphServiceClient(clientSecretCredential);


			//		//await graphClient.Me
			//		//	.SendMail(message, null)
			//		//	.Request()
			//		//	.PostAsync();
			//		var message = new Message
			//		{
			//			Subject = "Test1",
			//			Body = new ItemBody
			//			{
			//				ContentType = BodyType.Html,
			//				Content = "Test2"
			//			},
			//			ToRecipients = new List<Recipient>()
			//{
			//	new Recipient { EmailAddress = new EmailAddress { Address = "MyGraphUser@outlook.com" }}
			//}
			//		};

			//		// Send mail as the given user. 
			//		graphClient
			//			.Users["5c1f79a7-ca47-4239-bbb9-d14a16a89b02"]
			//			.SendMail(message, false)
			//			.Request()
			//			.PostAsync().Wait();
		}
    }
}

