using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Administration.AccountAdmin
{
    class CreateUserResponse
    {
        public CreateUserResponse(IRestResponse<CreateUserResponse> res)
        {
            StatusCode = res.StatusCode;
            if (res.StatusCode == HttpStatusCode.OK)
            {

            }
            else
            {
                Content = res.Content;
            }
        }

        public CreateUserResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
