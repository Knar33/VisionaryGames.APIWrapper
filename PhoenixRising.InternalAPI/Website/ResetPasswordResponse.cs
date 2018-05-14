using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Website
{
    public class ResetPasswordResponse
    {
        public ResetPasswordResponse(IRestResponse<ResetPasswordResponse> res)
        {
            StatusCode = res.StatusCode;
            Content = res.Content;
        }

        public ResetPasswordResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
