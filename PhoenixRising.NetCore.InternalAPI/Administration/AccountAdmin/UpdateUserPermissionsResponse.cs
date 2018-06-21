using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Administration.AccountAdmin
{
    public class UpdateUserPermissionsResponse
    {
        public UpdateUserPermissionsResponse(IRestResponse<UpdateUserPermissionsResponse> res)
        {
            StatusCode = res.StatusCode;
            Content = res.Content;
        }

        public UpdateUserPermissionsResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
