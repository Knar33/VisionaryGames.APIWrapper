using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Launcher
{
    public class GetFilesRequest
    {
        public GetFilesRequest(string connection, string build)
        {
            Connection = connection;
            Build = build;
        }

        public string Connection { get; set; }
        public string Build { get; set; }

        public GetFilesResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("launcher/builds/{build}", Method.GET);
            request.AddUrlSegment("build", Build);

            var res = client.Execute<List<GameFile>>(request);

            return new GetFilesResponse(res);
        }
    }
}
