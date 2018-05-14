using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Account
{
    public class FindResponse
    {
        public FindResponse(IRestResponse<FindResponse> res)
        {
            StatusCode = res.StatusCode;
            Content = res.Content;
            if (res.StatusCode == HttpStatusCode.OK)
            {
                USER_ID = res.Data.USER_ID;
            }
        }

        public FindResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public string USER_ID { get; set; }
    }
}
