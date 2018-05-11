using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Website
{
    class RequestResetPasswordRequest
    {
        public RequestResetPasswordRequest(APIConnection connection, string email)
        {
            Connection = connection;
            Email = email;
        }

        public string Email { get; set; }
        public APIConnection Connection { get; set; }

        public RequestResetPasswordResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("/app/account/passwd", Method.POST);
            request.AddHeader("userEmail", Email);

            var res = client.Execute<RequestResetPasswordResponse>(request);

            return new RequestResetPasswordResponse(res);
        }
    }
}
