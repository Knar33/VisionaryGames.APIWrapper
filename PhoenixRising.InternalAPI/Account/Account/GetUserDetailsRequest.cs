using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Account
{
    public class GetUserDetailsRequest
    {
        public GetUserDetailsRequest(string connection, string accessToken, Guid userID)
        {
            Connection = connection;
            AccessToken = accessToken;
            UserID = userID;
        }

        public string Connection { get; set; }
        public string AccessToken { get; set; }
        public Guid UserID { get; set; }

        public GetUserDetailsResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("account/{userID}", Method.GET);
            request.AddHeader("X-Access-Token", AccessToken);
            request.AddUrlSegment("userID", UserID);

            var res = client.Execute<GetUserDetailsResponse>(request);

            return new GetUserDetailsResponse(res);
        }
    }
}
