namespace TestFrameworkApp
{
    using Safaricom.Api.Core;
    using Safaricom.Api.Core.Types;
    using Safaricom.Api.Core.Types.Requests;
    using Safaricom.Api.Core.Types.Responses;

    using System;
    using System.Threading.Tasks;

    class Program
    {
        private const string consumerKey = "<CONSUMER KEY HERE>";
        private const string consumerSecret = "<CONSUMER SECRET HERE>";

        static void Main(string[] args)
        {
            try
            {
                MainAsync().Wait();

                Console.WriteLine("Api Call Was Successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an exception: {ex.ToString()}");
            }
        }

        static async Task<B2CPaymentResponse> MainAsync()
        {
            SafaricomApiClient _safaricomApiClient = new SafaricomApiClient(consumerKey, consumerSecret, ApiEnvironment.SandBox);

            B2CPaymentRequest _b2CPaymentRequest = new B2CPaymentRequest()
            .UsingSecurityCredential("Safaricom474!")
            .Entities("testapi474", "600474", "254708374149")
            .ForAmount(1000)
            .CallBackEndpoints("https://safaricom.api", "https://safaricom.api")
            .Comments("Test", "Test")
            .SetCommandID("BusinessPayment")
            .Instance;

            B2CPaymentResponse response = await _safaricomApiClient.PostPaymentRequestAsync(_b2CPaymentRequest);
            return response;
        }
    }
}
