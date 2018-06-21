using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Website
{
    public class VerifyUserRequest
    {
        public VerifyUserRequest(string connection, string appAccessToken, string resetToken)
        {
            Connection = connection;
            AppAccessToken = appAccessToken;
            ResetToken = resetToken;
        }
        
        public string Connection { get; set; }
        public string ResetToken { get; set; }
        public string AppAccessToken { get; set; }

        public VerifyUserResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("app/account/verify/{token}", Method.POST);
            request.AddUrlSegment("token", ResetToken);
            request.AddHeader("App-Access-Token", AppAccessToken);

            var res = client.Execute<VerifyUserResponse>(request);

            return new VerifyUserResponse(res);
        }
    }
}
