using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Website
{
    public class RequestResetPasswordResponse
    {
        public RequestResetPasswordResponse(IRestResponse<RequestResetPasswordResponse> res)
        {
            StatusCode = res.StatusCode;
            Content = res.Content;
        }

        public RequestResetPasswordResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
