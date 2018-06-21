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
        public ChangePasswordRequest(string connection, string accessToken, Guid userID, string oldPassword, string newPassword)
        {
            Connection = connection;
            AccessToken = accessToken;
            UserID = userID;
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }

        public string AccessToken { get; set; }
        public string Connection { get; set; }
        public Guid UserID { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public ChangePasswordResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("account/{userID}/passwd", Method.POST);
            request.AddUrlSegment("userID", UserID);
            request.AddHeader("X-Access-Token", AccessToken);
            request.AddHeader("Old-Password", OldPassword);
            request.AddHeader("New-Password", NewPassword);

            var res = client.Execute<ChangePasswordResponse>(request);

            return new ChangePasswordResponse(res);
        }
    }
}
