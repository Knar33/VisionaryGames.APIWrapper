using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Website
{
    public class VerifyUserResponse
    {
        public VerifyUserResponse(IRestResponse<VerifyUserResponse> res)
        {
            StatusCode = res.StatusCode;
            Content = res.Content;
        }

        public VerifyUserResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
