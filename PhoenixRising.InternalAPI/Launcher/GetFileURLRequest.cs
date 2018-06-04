using RestSharp;

namespace PhoenixRising.InternalAPI.Launcher
{
    public class GetFileURLRequest
    {

        public GetFileURLRequest(string connection, string accessToken, string endpoint, string filePath)
        {
            Connection = connection;
            AccessToken = accessToken;
            Endpoint = endpoint;
            FilePath = filePath;
        }

        public string Connection { get; set; }
        public string AccessToken { get; set; }
        public string Endpoint { get; set; }
        public string FilePath { get; set; }

        public GetFileURLResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("launcher/file", Method.GET);
            request.AddHeader("X-Access-Token", AccessToken);
            request.AddHeader("Container", Endpoint);
            request.AddHeader("Path", FilePath);

            var res = client.Execute<GetFileURLResponse>(request);

            return new GetFileURLResponse(res);
        }

    }
}
