using RestSharp;
using System.Net;

namespace PhoenixRising.InternalAPI.Launcher
{
    public class GetFileURLResponse
    {

        public GetFileURLResponse(IRestResponse<GetFileURLResponse> res)
        {
            StatusCode = res.StatusCode;
            Content = res.Content.Replace("\"", "");
        }

        public GetFileURLResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }

    }
}
