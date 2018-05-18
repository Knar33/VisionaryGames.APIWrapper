using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Administration.AccountAdmin
{
    public class UpdateUserPermissionsRequest
    {
        public UpdateUserPermissionsRequest(string connection, string accessToken, Guid userID)
        {
            Connection = connection;
            AccessToken = accessToken;
            UserID = userID;
        }

        public string Connection { get; set; }
        public string AccessToken { get; set; }
        public Guid UserID { get; set; }
        public int Developer { get; set; }
        public int Administrator { get; set; }
        public int Banned { get; set; }

        public UpdateUserPermissionsResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("account/{userID}", Method.POST);
            request.AddUrlSegment("userID", UserID);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { Developer = Developer, Administrator = Administrator, Banned = Banned});
            request.AddHeader("X-Access-Token", AccessToken);

            var res = client.Execute<UpdateUserPermissionsResponse>(request);

            return new UpdateUserPermissionsResponse(res);
        }
    }
}
