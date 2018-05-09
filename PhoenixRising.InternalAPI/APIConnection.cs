using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixRising.InternalAPI
{
    public class APIConnection
    {
        public APIConnection(string url)
        {
            URL = url;
        }

        public APIConnection(string url, string authenticationToken)
        {
            URL = url;
            AuthenticationToken = authenticationToken;
        }

        public string URL { get; set; }
        public string AuthenticationToken { get; set; }
    }
}
