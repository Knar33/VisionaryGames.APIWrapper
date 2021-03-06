﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.SettingsHud
{
    class GetHUDListResponse
    {
        public GetHUDListResponse(IRestResponse<GetHUDListResponse> res)
        {
            StatusCode = res.StatusCode;
            if (res.StatusCode == HttpStatusCode.OK)
            {
                //TODO: get JSON response for this
            }
            else
            {
                Content = res.Content;
            }
        }

        public GetHUDListResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
