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
        public ResetPasswordRequest(APIConnection connection, string nickname)
        {
            Connection = connection;
            Nickname = nickname;
        }

        public string Nickname { get; set; }
        public APIConnection Connection { get; set; }

        public ResetPasswordResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("account/find/{nickname}", Method.GET);
            request.AddUrlSegment("nickname", Nickname);

            var res = client.Execute<ResetPasswordResponse>(request);

            return new ResetPasswordResponse(res);
        }
    }
}
