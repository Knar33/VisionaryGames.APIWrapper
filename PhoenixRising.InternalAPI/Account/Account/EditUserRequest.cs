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
        public EditUserRequest(APIConnection connection, AuthenticationStore auth)
        {
            Connection = connection;
            Auth = auth;
        }

        public AuthenticationStore Auth { get; set; }
        public APIConnection Connection { get; set; }
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nicknane { get; set; }
        public string Password { get; set; }

        public EditUserResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("account/{userID}", Method.POST);
            request.AddUrlSegment("userID", UserID);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { USER_FNAME = FirstName, USER_LNAME = LastName, USER_EMAIL = Email, USER_NICK = Nicknane, USER_PASS = Password });
            request.AddHeader("X-Access-Token", Auth.AccessToken);

            var res = client.Execute<EditUserResponse>(request);

            return new EditUserResponse(res);
        }
    }
}
