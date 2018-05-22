using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Account
{
    public class ResendVerificationRequest
    {
        public ResendVerificationRequest(string connection, string appAccessToken, string email)
        {
            Connection = connection;
            AppAccessToken = appAccessToken;
            Email = email;
        }

        public string Connection { get; set; }
        public string AppAccessToken { get; set; }
        public string Email { get; set; }

        public ResendVerificationResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("app/account/verify", Method.POST);
            request.AddHeader("App-Access-Token", AppAccessToken);
            request.AddHeader("Email", Email);

            var res = client.Execute<ResendVerificationResponse>(request);

            return new ResendVerificationResponse(res);
        }
    }
}
