using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixRising.InternalAPI.App.DownloadURL
{
    public class DownloadClientRequest
    {
        public DownloadClientRequest(string connection, string appAccessToken)
        {
            Connection = connection;
            AppAccessToken = appAccessToken;
        }

        public string Connection { get; set; }
        public string AppAccessToken { get; set; }

        public DownloadClientResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("app/download/client", Method.GET);
            request.AddHeader("App-Access-Token", AppAccessToken);

            var res = client.Execute<DownloadClientResponse>(request);

            return new DownloadClientResponse(res);
        }

    }
}
