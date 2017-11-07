namespace TestFrameworkApp
{
    using Newtonsoft.Json;
    using Safaricom.Api.Core;
    using Safaricom.Api.Core.Types;
    using Safaricom.Api.Core.Types.Requests;
    using Safaricom.Api.Core.Types.Responses;

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    class Program
    {
        private const string _consumerKey = "<CONSUMER KEY HERE>";
        private const string _consumerSecret = "<CONSUMER SECRET HERE>";

        static SafaricomApiClient _safaricomApiClient = new SafaricomApiClient(_consumerKey, _consumerSecret, ApiEnvironment.SandBox);

        static void Main(string[] args)
        {
            try
            {
                B2CAsync().Wait();
                B2BAsync().Wait();
                AccountBalanceAsync().Wait();
                TransactionStatusRequestAsync().Wait();
                ReversalRequestAsync().Wait();

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

        static async Task<TransactionStatusResponse> TransactionStatusRequestAsync()
        {
            TransactionStatusRequest _transactionStatusRequest = new TransactionStatusRequest()
                           .AsSecurityCredential("Safaricom481$")
                           .AsEntity("testapi481", "600481")
                           .AsAmount(1000)
                           .AsIdentifierType(1)
                           .AsCommandID("TransactionStatusQuery")
                           .AsComments("Test", "Test")
                           .AsTransactionID("LKXXXX1234")
                           .AsEndpoints("https://safaricom.api", "https://safaricom.api");

            TransactionStatusResponse _response = await _safaricomApiClient.PostPaymentRequestAsync(_transactionStatusRequest);

            if (_response.ErrorCode == null)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("===Transaction Status Success Response=====");
                Console.WriteLine("===========================================");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(_response.OriginatorConversationID + Environment.NewLine + _response.ConversationID + Environment.NewLine + _response.ResponseDescription);
                Console.WriteLine(Environment.NewLine);
            }

            else
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("=====Transaction Status Error Response=====");
                Console.WriteLine("===========================================");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(_response.ErrorCode + Environment.NewLine + _response.ErrorMessage + Environment.NewLine + _response.ErrorRequestId);
                Console.WriteLine(Environment.NewLine);
            }

            return _response;
        }

        static async Task<ReversalResponse> ReversalRequestAsync()
        {
            Dictionary<string, string> _parameters = new Dictionary<string, string>();
            _parameters.Add("Initiator", "testapi481");
            _parameters.Add("SecurityCredential", "Safaricom481$");
            _parameters.Add("CommandID", "TransactionReversal");
            _parameters.Add("TransactionID", "LKXXXX1234");
            _parameters.Add("Amount", 1000.ToString());
            _parameters.Add("ReceiverParty", "600481");
            _parameters.Add("RecieverIdentifierType", "4");
            _parameters.Add("ResultURL", "https://safaricom.api");
            _parameters.Add("QueueTimeOutURL", "https://safaricom.api");
            _parameters.Add("Remarks", "Test");
            _parameters.Add("Occasion", "Test");

            string _reversalResponse = await _safaricomApiClient.Execute("mpesa/reversal/v1/request", _parameters);

            ReversalResponse _response = JsonConvert.DeserializeObject<ReversalResponse>(_reversalResponse);

            if (_response.ErrorCode == null)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("=====Reversal Request Success Response=====");
                Console.WriteLine("===========================================");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(_response.OriginatorConversationID + Environment.NewLine + _response.ConversationID + Environment.NewLine + _response.ResponseDescription);
                Console.WriteLine(Environment.NewLine);
            }

            else
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("======Reversal Request Error Response======");
                Console.WriteLine("===========================================");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(_response.ErrorCode + Environment.NewLine + _response.ErrorMessage + Environment.NewLine + _response.ErrorRequestId);
                Console.WriteLine(Environment.NewLine);
            }

            return _response;
        }
    }
}
