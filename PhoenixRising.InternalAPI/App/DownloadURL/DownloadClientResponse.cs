using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixRising.InternalAPI.App.DownloadURL
{
    public class DownloadClientResponse
    {

        public DownloadClientResponse(IRestResponse<DownloadClientResponse> res)
        {
            StatusCode = res.StatusCode;
            Content = res.Content.Replace("\"", "");
        }

        public DownloadClientResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }

    }
}
