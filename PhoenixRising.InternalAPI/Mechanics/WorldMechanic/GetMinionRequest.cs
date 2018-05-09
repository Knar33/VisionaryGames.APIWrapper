using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Mechanics.WorldMechanic
{
    class GetMinionRequest
    {
        public GetMinionRequest(AuthenticationStore auth, APIConnection connection)
        {
            Auth = auth;
            Connection = connection;
            UserID = auth.UserID;
        }

        public Guid UserID { get; set; }
        public AuthenticationStore Auth { get; set; }
        public APIConnection Connection { get; set; }

        public GetMinionResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("account/{userID}/ping", Method.POST);
            request.AddHeader("X-Access-Token", Auth.AccessToken);
            request.AddUrlSegment("userID", UserID);

            var res = client.Execute<GetMinionResponse>(request);

            return new GetMinionResponse(res);
        }
    }
}
