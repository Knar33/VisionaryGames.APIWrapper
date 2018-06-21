using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Website
{
    public class CreateUserRequest
    {
        public CreateUserRequest(string connection, string appAccessToken)
        {
            Connection = connection;
            AppAccessToken = appAccessToken;
        }
        
        public string Connection { get; set; }
        public string AppAccessToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nicknane { get; set; }
        public string Password { get; set; }

        public CreateUserResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("app/account", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { USER_FNAME = FirstName, USER_LNAME = LastName, USER_EMAIL = Email, USER_NICK = Nicknane, USER_PASS = Password });
            request.AddHeader("App-Access-Token", AppAccessToken);

            var res = client.Execute<CreateUserResponse>(request);

            return new CreateUserResponse(res);
        }
    }
}
