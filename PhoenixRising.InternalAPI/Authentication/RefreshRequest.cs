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
        public RefreshRequest(AuthenticationStore auth, APIConnection connection)
        {
            Auth = auth;
            Connection = connection;
        }
        
        public AuthenticationStore Auth { get; set; }
        public APIConnection Connection { get; set; }

        public RefreshResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("auth/refresh", Method.GET);
            request.AddHeader("X-Refresh-Token", Auth.RefreshToken);

            var res = client.Execute<RefreshResponse>(request);

            return new RefreshResponse(res);
        }
    }
}
