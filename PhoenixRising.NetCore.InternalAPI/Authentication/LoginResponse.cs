using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Authentication
{
    public class LoginResponse
    {
        public LoginResponse(IRestResponse<LoginResponse> res)
        {
            StatusCode = res.StatusCode;
            Content = res.Content;
            if (res.StatusCode == HttpStatusCode.OK)
            {
                user_id = res.Data.user_id;
                access_token = res.Data.access_token;
                expireTime = res.Data.expireTime;
                refresh_token = res.Data.refresh_token;
                user_nick = res.Data.user_nick;
            }
        }

        public LoginResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        
        public string user_id { get; set; }
        public string access_token { get; set; }
        public string expireTime { get; set; }
        public string refresh_token { get; set; }
        public string user_nick { get; set; }
    }
}
