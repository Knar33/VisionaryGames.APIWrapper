using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.SettingsHud
{
    class GetHUDRequest
    {
        public GetHUDRequest(AuthenticationStore auth, APIConnection connection)
        {
            Auth = auth;
            Connection = connection;
        }

        public string HudID { get; set; }
        public AuthenticationStore Auth { get; set; }
        public APIConnection Connection { get; set; }

        public GetHUDResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("account/settings/hud/{hudID}", Method.GET);
            request.AddHeader("X-Access-Token", Auth.AccessToken);
            request.AddUrlSegment("hudID", HudID);

            var res = client.Execute<GetHUDResponse>(request);

            return new GetHUDResponse(res);
        }
    }
}
