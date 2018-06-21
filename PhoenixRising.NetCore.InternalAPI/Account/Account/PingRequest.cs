using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Account
{
    public class PingRequest
    {
        public PingRequest(string connection, string accessToken, Guid userID)
        {
            Connection = connection;
            AccessToken = accessToken;
            UserID = userID;
        }

        public string Connection { get; set; }
        public string AccessToken { get; set; }
        public Guid UserID { get; set; }

        public PingResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("account/{userID}/ping", Method.POST);
            request.AddHeader("X-Access-Token", AccessToken);
            request.AddUrlSegment("userID", UserID);

            var res = client.Execute<PingResponse>(request);

            return new PingResponse(res);
        }
    }
}
