﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.SettingsHud
{
    class GetHUDResponse
    {
        public GetHUDResponse(IRestResponse<GetHUDResponse> res)
        {
            StatusCode = res.StatusCode;
            if (res.StatusCode == HttpStatusCode.OK)
            {
                //TODO:
            }
            else
            {
                Content = res.Content;
            }
        }

        public GetHUDResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
