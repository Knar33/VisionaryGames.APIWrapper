using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Website
{
    public class RequestResetPasswordRequest
    {
        public RequestResetPasswordRequest(string connection, string appAccessToken, string email)
        {
            Connection = connection;
            AppAccessToken = appAccessToken;
            Email = email;
        }

        public string Email { get; set; }
        public string AppAccessToken { get; set; }
        public string Connection { get; set; }

        public RequestResetPasswordResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("/app/account/passwd", Method.POST);
            request.AddHeader("userEmail", Email);
            request.AddHeader("App-Access-Token", AppAccessToken);

            var res = client.Execute<RequestResetPasswordResponse>(request);

            return new RequestResetPasswordResponse(res);
        }
    }
}
