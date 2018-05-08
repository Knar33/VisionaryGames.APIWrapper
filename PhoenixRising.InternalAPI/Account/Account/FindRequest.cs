using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Account
{
    public class FindRequest
    {
        public FindRequest(APIConnection connection, string nickname)
        {
            Connection = connection;
            Nickname = nickname;
        }

        public string Nickname { get; set; }
        public APIConnection Connection { get; set; }

        public FindResponse Send()
        {
            var client = new RestClient(Connection.URL);

            var request = new RestRequest("v1/account/find/{nickname}", Method.GET);
            request.AddUrlSegment("nickname", Nickname);
            
            var res = client.Execute<FindResponse>(request);
            FindResponse response = res.Data;
            response.Content = res.Content;
            response.StatusCode = res.StatusCode;

            return response;
        }
    }
}
