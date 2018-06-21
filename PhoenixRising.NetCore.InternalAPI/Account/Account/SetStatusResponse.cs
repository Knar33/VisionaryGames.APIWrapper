using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Account
{
    public class SetStatusResponse
    {
        public SetStatusResponse(IRestResponse<SetStatusResponse> res)
        {
            StatusCode = res.StatusCode;
            Content = res.Content;
        }

        public SetStatusResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
