using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Website
{
    class ResetPasswordRequest
    {
        public ResetPasswordRequest(APIConnection connection, string passwordToken, string password)
        {
            Connection = connection;
            PasswordToken = passwordToken;
            Password = password;
        }

        public string PasswordToken { get; set; }
        public string Password { get; set; }
        public APIConnection Connection { get; set; }

        public ResetPasswordResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("app/account/passwd/{token}", Method.POST);
            request.AddUrlSegment("token", PasswordToken);
            request.AddHeader("Password", Password);

            var res = client.Execute<ResetPasswordResponse>(request);

            return new ResetPasswordResponse(res);
        }
    }
}
