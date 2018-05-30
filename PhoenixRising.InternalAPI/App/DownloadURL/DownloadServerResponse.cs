using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixRising.InternalAPI.App.DownloadURL
{
    public class DownloadServerResponse
    {

        public DownloadServerResponse(IRestResponse<DownloadClientResponse> res)
        {
            StatusCode = res.StatusCode;
            Content = res.Content;
        }

        public DownloadServerResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }

    }
}
