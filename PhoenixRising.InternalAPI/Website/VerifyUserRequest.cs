using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Website
{
    public class VerifyUserRequest
    {
        public VerifyUserRequest(APIConnection connection, AuthenticationStore auth)
        {
            Connection = connection;
            Auth = auth;
        }

        public AuthenticationStore Auth { get; set; }
        public APIConnection Connection { get; set; }
        public string Token { get; set; }
        public string AppAccessToken { get; set; }

        public VerifyUserResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("app/account/verify/{token}", Method.POST);
            request.AddUrlSegment("token", Token);
            request.AddHeader("App-Access-Token", AppAccessToken);

            var res = client.Execute<VerifyUserResponse>(request);

            return new VerifyUserResponse(res);
        }
    }
}
