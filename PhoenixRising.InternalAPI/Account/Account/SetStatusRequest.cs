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
        public SetStatusRequest(AuthenticationStore auth, APIConnection connection, OnlineStatus onlineStatus, GameStatus gameStatus)
        {
            Auth = auth;
            Connection = connection;
            UserID = auth.UserID;
            Status = ((int)onlineStatus).ToString() + ',' + ((int)gameStatus).ToString();
        }

        public Guid UserID { get; set; }
        public AuthenticationStore Auth { get; set; }
        public APIConnection Connection { get; set; }
        public string Status { get; set; }

        public SetStatusResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("account/{userID}/status", Method.POST);
            request.AddHeader("X-Access-Token", Auth.AccessToken);
            request.AddHeader("status", Status);
            request.AddUrlSegment("userID", UserID);

            var res = client.Execute<SetStatusResponse>(request);

            return new SetStatusResponse(res);
        }
    }

    public enum OnlineStatus
    {
        OFFLINE = 0,
        ONLINE = 1,
        AWAY = 2,
        BUSY = 4
    };

    public enum GameStatus
    {
        OFFLINE = 0,
        INMENU = 1,
        INLOBBY = 2,
        INGAME = 4
    };
}
