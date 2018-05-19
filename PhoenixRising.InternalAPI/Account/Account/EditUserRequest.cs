using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Account
{
    public class EditUserRequest
    {
        public EditUserRequest(string connection, string accessToken, Guid userID)
        {
            Connection = connection;
            AccessToken = accessToken;
            UserID = userID;
        }
        
        public string Connection { get; set; }
        public string AccessToken { get; set; }
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nicknane { get; set; }
        public string Password { get; set; }

        public EditUserResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("account/{userID}", Method.POST);
            request.AddUrlSegment("userID", UserID);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { USER_FNAME = FirstName, USER_LNAME = LastName, USER_EMAIL = Email, USER_NICK = Nicknane });
            request.AddHeader("X-Access-Token", AccessToken);
            if (Password != null)
            {
                request.AddHeader("Password", Password);
            }

            var res = client.Execute<EditUserResponse>(request);

            return new EditUserResponse(res);
        }
    }
}
