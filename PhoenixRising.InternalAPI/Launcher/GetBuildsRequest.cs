using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Launcher
{
    public class GetBuildsRequest
    {
        public GetBuildsRequest(string connection)
        {
            Connection = connection;
        }

        public string Connection { get; set; }

        public GetBuildsResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("launcher/builds", Method.GET);

            var res = client.Execute<List<Builds>>(request);

            return new GetBuildsResponse(res);
        }
    }
}
