﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixRising.InternalAPI.App.Download
{
    public class DownloadClientResponse
    {

        public DownloadClientResponse(IRestResponse<DownloadClientResponse> res)
        {
            StatusCode = res.StatusCode;
            Content = res.Content;
        }

        public DownloadClientResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }

    }
}
