using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Authentication
{
    public class RefreshResponse
    {
        public RefreshResponse(IRestResponse<RefreshResponse> res)
        {
            StatusCode = res.StatusCode;
            Content = res.Content;
            if (res.StatusCode == HttpStatusCode.OK)
            {
                access_token = res.Data.access_token;
                expireTime = res.Data.expireTime;
                user_id = res.Data.user_id;
                user_nick = res.Data.user_nick;
            }
        }

        public RefreshResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        
        public string access_token { get; set; }
        public string expireTime { get; set; }
        public string user_id { get; set; }
        public string user_nick { get; set; }
    }
}
