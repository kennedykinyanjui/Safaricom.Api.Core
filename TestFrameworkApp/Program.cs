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
        //private const string consumerKey = "<CONSUMER KEY HERE>";
        //private const string consumerSecret = "<CONSUMER SECRET HERE>";

        private const string _consumerKey = "VSjc13kefLJtZERAgUHZ0Rurk5AXeqib";
        private const string _consumerSecret = "cBD5k90cRFNK42xz";

        static SafaricomApiClient _safaricomApiClient = new SafaricomApiClient(_consumerKey, _consumerSecret, ApiEnvironment.SandBox);

        static void Main(string[] args)
        {
            try
            {
                B2CAsync().Wait();
                B2BAsync().Wait();
                AccountBalanceAsync().Wait();

                Console.WriteLine("Api Call Was Successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an exception: {ex.ToString()}");
            }
        }

        static async Task<B2CPaymentResponse> B2CAsync()
        {
            B2CPaymentRequest _b2CPaymentRequest = new B2CPaymentRequest()
            .UsingSecurityCredential("Safaricom481$")
            .Entities("testapi481", "600481", "254708374149")
            .ForAmount(1000)
            .CallBackEndpoints("https://safaricom.api", "https://safaricom.api")
            .Comments("Test", "Test")
            .SetCommandID("BusinessPayment")
            .Instance;

            B2CPaymentResponse _response = await _safaricomApiClient.PostPaymentRequestAsync(_b2CPaymentRequest);

            if (_response.ErrorCode == null)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("===========B2C Success Response============");
                Console.WriteLine("===========================================");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(_response.ConversationID + Environment.NewLine + _response.OriginatorConversationID + Environment.NewLine +  _response.ResponseDescription);
                Console.WriteLine(Environment.NewLine);
            }

            else
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("============B2C Error Response=============");
                Console.WriteLine("===========================================");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(_response.ErrorCode + Environment.NewLine + _response.ErrorMessage + Environment.NewLine + _response.ErrorRequestId);
                Console.WriteLine(Environment.NewLine);
            }

            return _response;
        }

        static async Task<B2BPaymentResponse> B2BAsync()
        {
            B2BPaymentRequest _b2BPaymentRequest = new B2BPaymentRequest()
            .UsingSecurityCredential("Safaricom474!")
            .Entity("testapi474", "600474", "600000")
            .ForAmount(1000)
            .CallBackEndpoints("https://safaricom.api", "https://safaricom.api")
            .Comments("Test")
            .SetSenderIdentifierType(4)
            .SetRecieverIdentifierType(1)
            .SetAccountReference("Test")
            .SetCommandID("BusinessBuyGoods")
            .Instance;

            B2BPaymentResponse _response = await _safaricomApiClient.PostPaymentRequestAsync(_b2BPaymentRequest);

            if (_response.ErrorCode == null)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("===========B2B Success Response============");
                Console.WriteLine("===========================================");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(_response.ConversationID + Environment.NewLine + _response.OriginatorConversationID + Environment.NewLine + _response.ResponseDescription);
                Console.WriteLine(Environment.NewLine);
            }

            else
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("============B2B Error Response=============");
                Console.WriteLine("===========================================");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(_response.ErrorCode + Environment.NewLine + _response.ErrorMessage + Environment.NewLine + _response.ErrorRequestId);
                Console.WriteLine(Environment.NewLine);
            }

            return _response;
        }

        static async Task<AccountBalanceResponse> AccountBalanceAsync()
        {
            AccountBalanceRequest _accountBalanceRequest = new AccountBalanceRequest()
                           .AsSecurityCredential("Safaricom474!")
                           .AsEntity("testapi474", "600474")
                           .AsCommandID("AccountBalance")
                           .AsEndpoints("https://safaricom.api", "https://safaricom.api")
                           .AsComments("Test")
                           .AsIdentifierType(4);

            AccountBalanceResponse _response = await _safaricomApiClient.PostPaymentRequestAsync(_accountBalanceRequest);

            if (_response.ErrorCode == null)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("=====Account Balance Success Response======");
                Console.WriteLine("===========================================");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(_response.OriginatorConversationID + Environment.NewLine + _response.ConversationID + Environment.NewLine + _response.ResponseDescription);
                Console.WriteLine(Environment.NewLine);
            }

            else
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("======Account Balance Error Response=======");
                Console.WriteLine("===========================================");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(_response.ErrorCode + Environment.NewLine + _response.ErrorMessage + Environment.NewLine + _response.ErrorRequestId);
                Console.WriteLine(Environment.NewLine);
            }

            return _response;
        }
    }
}
