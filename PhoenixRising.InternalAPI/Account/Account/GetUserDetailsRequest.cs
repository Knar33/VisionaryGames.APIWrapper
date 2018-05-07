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
        public GetUserDetailsRequest(AuthenticationStore auth, APIConnection connection, string userID)
        {
            Auth = auth;
            Connection = connection;
            UserID = userID;
        }

        public string UserID { get; set; }
        public AuthenticationStore Auth { get; set; }
        public APIConnection Connection { get; set; }

        public GetUserDetailsResponse Send()
        {
            var client = new RestClient(Connection.URL);

            var request = new RestRequest("v1/account/{userID}", Method.GET);
            request.AddHeader("X-Access-Token", Auth.AccessToken);
            request.AddUrlSegment("nickname", UserID);

            var res = client.Execute<GetUserDetailsResponse>(request);
            GetUserDetailsResponse response = res.Data;
            response.Content = res.Content;
            response.StatusCode = res.StatusCode;

            return response;
        }
    }
}
