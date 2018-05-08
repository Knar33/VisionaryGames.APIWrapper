using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Authentication
{
    public class LoginRequest
    {
        public LoginRequest(APIConnection connection, string username, string password)
        {
            Connection = connection;
            Username = username;
            Password = password;
        }
        
        public AuthenticationStore Auth { get; set; }
        public APIConnection Connection { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("auth/login", Method.POST);
            request.AddHeader("Username", Username);
            request.AddHeader("Password", Password);

            var res = client.Execute<LoginResponse>(request);

            return new LoginResponse(res);
        }
    }
}
