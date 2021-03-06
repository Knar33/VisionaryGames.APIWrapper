﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Launcher
{
    public class GetFilesResponse
    {
        public GetFilesResponse(IRestResponse<List<GameFIle>> res)
        {
            StatusCode = res.StatusCode;
            if (res.StatusCode == HttpStatusCode.OK)
            {
                Content = res.Data;
            }
        }

        public GetFilesResponse()
        {

        }

        public List<GameFIle> Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }

    public class GameFIle
    {
        public string FILE_NAME { get; set; }
        public string FILE_PATH { get; set; }
        public int FILE_SIZE { get; set; }
        public string CHECKSUM { get; set; }
    }
}
