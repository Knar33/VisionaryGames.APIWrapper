using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Website
{
    class RequestResetPasswordResponse
    {
        public RequestResetPasswordResponse(IRestResponse<RequestResetPasswordResponse> res)
        {
            StatusCode = res.StatusCode;
            if (res.StatusCode != HttpStatusCode.OK)
            {
                Content = res.Content;
            }
        }

        public RequestResetPasswordResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
