using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Account
{
    public class ChangePasswordRequest
    {
        public ChangePasswordRequest(APIConnection connection, AuthenticationStore auth)
        {
            Connection = connection;
            Auth = auth;
            UserID = auth.UserID;
        }

        public AuthenticationStore Auth { get; set; }
        public APIConnection Connection { get; set; }
        public Guid UserID { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public ChangePasswordResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("account/{userID}/passwd", Method.POST);
            request.AddUrlSegment("userID", Auth.UserID);
            request.AddHeader("X-Access-Token", Auth.AccessToken);
            request.AddHeader("Old-Password", OldPassword);
            request.AddHeader("New-Password", NewPassword);

            var res = client.Execute<ChangePasswordResponse>(request);

            return new ChangePasswordResponse(res);
        }
    }
}
