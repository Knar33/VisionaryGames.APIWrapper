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
        public ResendVerificationRequest(string connection, string accessToken, Guid userID)
        {
            Connection = connection;
            AccessToken = accessToken;
            UserID = userID;
        }

        public string Connection { get; set; }
        public string AccessToken { get; set; }
        public Guid UserID { get; set; }

        public ResendVerificationResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("account/{userID}/verify", Method.POST);
            request.AddHeader("X-Access-Token", AccessToken);
            request.AddUrlSegment("userID", UserID);

            var res = client.Execute<ResendVerificationResponse>(request);

            return new ResendVerificationResponse(res);
        }
    }
}
