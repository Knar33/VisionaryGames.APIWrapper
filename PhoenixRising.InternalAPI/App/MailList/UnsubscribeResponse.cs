using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.App.MailList
{
    public class UnsubscribeResponse
    {
        public UnsubscribeResponse(IRestResponse<UnsubscribeResponse> res)
        {
            StatusCode = res.StatusCode;
            Content = res.Content;
        }

        public UnsubscribeResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
