using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Friends
{
    public class DeleteFriendRequest
    {
        public DeleteFriendRequest(AuthenticationStore auth, APIConnection connection)
        {
            Auth = auth;
            Connection = connection;
            UserID = auth.UserID;
        }

        public Guid UserID { get; set; }
        public AuthenticationStore Auth { get; set; }
        public APIConnection Connection { get; set; }
        public Guid IDFriend { get; set; }

        public DeleteFriendResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("account/{userID}/friends/delete", Method.POST);
            request.AddHeader("X-Access-Token", Auth.AccessToken);
            request.AddHeader("ID-Friend", IDFriend.ToString());
            request.AddUrlSegment("userID", UserID);

            var res = client.Execute<DeleteFriendResponse>(request);

            return new DeleteFriendResponse(res);
        }
    }
}
