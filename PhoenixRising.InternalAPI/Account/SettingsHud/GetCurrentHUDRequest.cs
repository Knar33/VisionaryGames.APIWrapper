using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.SettingsHud
{
    class GetCurrentHUDRequest
    {
        public GetCurrentHUDRequest(AuthenticationStore auth, APIConnection connection)
        {
            Auth = auth;
            Connection = connection;
            UserID = auth.UserID;
        }

        public Guid UserID { get; set; }
        public AuthenticationStore Auth { get; set; }
        public APIConnection Connection { get; set; }

        public GetCurrentHUDResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("account/{userID}/settings/hud", Method.GET);
            request.AddHeader("X-Access-Token", Auth.AccessToken);
            request.AddUrlSegment("userID", UserID);

            var res = client.Execute<GetCurrentHUDResponse>(request);

            return new GetCurrentHUDResponse(res);
        }
    }
}
