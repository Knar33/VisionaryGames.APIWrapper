using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Friends
{
    public class UpdateStatusRequest
    {
        public UpdateStatusRequest(AuthenticationStore auth, APIConnection connection)
        {
            Auth = auth;
            Connection = connection;
            UserID = auth.UserID;
        }

        public Guid UserID { get; set; }
        public AuthenticationStore Auth { get; set; }
        public APIConnection Connection { get; set; }
        public Guid IDFriend { get; set; }
        public bool BlockUser { get; set; }

        public UpdateStatusResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("account/{userID}/friends", Method.POST);
            request.AddHeader("X-Access-Token", Auth.AccessToken);
            request.AddHeader("ID-Friend", IDFriend.ToString());
            request.AddHeader("Block-User", Convert.ToInt32(BlockUser).ToString());
            request.AddUrlSegment("userID", UserID);

            var res = client.Execute<UpdateStatusResponse>(request);

            return new UpdateStatusResponse(res);
        }
    }
}
