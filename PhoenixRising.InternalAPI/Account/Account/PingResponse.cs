﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Account
{
    class PingResponse
    {
        public PingResponse(IRestResponse<PingResponse> res)
        {
            StatusCode = res.StatusCode;
            if (res.StatusCode != HttpStatusCode.OK)
            { 
                Content = res.Content;
            }
        }

        public PingResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
