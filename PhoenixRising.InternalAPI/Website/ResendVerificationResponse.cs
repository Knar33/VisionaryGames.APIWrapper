using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Account
{
    public class ResendVerificationResponse
    {
        public ResendVerificationResponse(IRestResponse<ResendVerificationResponse> res)
        {
            StatusCode = res.StatusCode;
            Content = res.Content;
        }

        public ResendVerificationResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
