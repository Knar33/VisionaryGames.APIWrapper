using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Authentication
{
    public class RefreshRequest
    {
        public RefreshRequest(string connection, string refreshToken)
        {
            Connection = connection;
            RefreshToken = refreshToken;
        }

        public string Connection { get; set; }
        public string RefreshToken { get; set; }

        public RefreshResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("auth/refresh", Method.GET);
            request.AddHeader("X-Refresh-Token", RefreshToken);

            var res = client.Execute<RefreshResponse>(request);

            return new RefreshResponse(res);
        }
    }
}
