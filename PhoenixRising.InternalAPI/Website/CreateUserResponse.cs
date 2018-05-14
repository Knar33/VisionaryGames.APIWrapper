using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Website
{
    public class CreateUserResponse
    {
        public CreateUserResponse(IRestResponse<CreateUserResponse> res)
        {
            StatusCode = res.StatusCode;
            Content = res.Content;
            if (res.StatusCode == HttpStatusCode.OK)
            {
                USER_ID = res.Data.USER_ID;
            }
        }

        public CreateUserResponse()
        {

        }

        public Guid USER_ID { get; set; }
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
