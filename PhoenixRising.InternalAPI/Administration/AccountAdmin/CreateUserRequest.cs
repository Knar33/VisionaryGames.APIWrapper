using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Administration.AccountAdmin
{
    class CreateUserRequest
    {
        public CreateUserRequest(AuthenticationStore auth, APIConnection connection)
        {
            Auth = auth;
            Connection = connection;
            UserID = auth.UserID;
        }

        public Guid UserID { get; set; }
        public AuthenticationStore Auth { get; set; }
        public APIConnection Connection { get; set; }

        public CreateUserResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("account/{userID}/ping", Method.POST);
            request.AddHeader("X-Access-Token", Auth.AccessToken);
            request.AddUrlSegment("userID", UserID);

            var res = client.Execute<CreateUserResponse>(request);

            return new CreateUserResponse(res);
        }
    }
}
