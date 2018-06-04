using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Launcher
{
    public class GetBuildsResponse
    {
        public GetBuildsResponse(IRestResponse<List<Builds>> res)
        {
            StatusCode = res.StatusCode;
            if (res.StatusCode == HttpStatusCode.OK)
            {
                Builds = res.Data;
            }
        }

        public GetBuildsResponse()
        {

        }

        public List<Builds> Builds { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }

    public class Builds
    {
        public string BUILD_VERSION { get; set; }
        public string CODE_NAME { get; set; }
        public string END_POINT { get; set; }
    }
}
