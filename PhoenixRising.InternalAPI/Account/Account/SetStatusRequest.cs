using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Account
{
    public class SetStatusRequest
    {
        public SetStatusRequest(AuthenticationStore auth, APIConnection connection)
        {
            Auth = auth;
            Connection = connection;
            UserID = auth.UserID;
        }

        public Guid UserID { get; set; }
        public AuthenticationStore Auth { get; set; }
        public APIConnection Connection { get; set; }
        //TODO: status format? Split this out into multiple ints for constructor
        public string Status { get; set; }

        public SetStatusResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("account/{userID}/status", Method.POST);
            request.AddHeader("X-Access-Token", Auth.AccessToken);
            request.AddHeader("status", Auth.AccessToken);
            request.AddUrlSegment("userID", UserID);

            var res = client.Execute<SetStatusResponse>(request);

            return new SetStatusResponse(res);
        }
    }
}
