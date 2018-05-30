using RestSharp;

namespace PhoenixRising.InternalAPI.App.DownloadURL
{
    public class DownloadServerRequest
    {
        public DownloadServerRequest(string connection, string appAccessToken)
        {
            Connection = connection;
            AppAccessToken = appAccessToken;
        }

        public string Connection { get; set; }
        public string AppAccessToken { get; set; }

        public DownloadServerResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("app/download/server", Method.GET);
            request.AddHeader("App-Access-Token", AppAccessToken);

            var res = client.Execute<DownloadClientResponse>(request);

            return new DownloadServerResponse(res);
        }

    }
}
