using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace PhoenixRising.InternalAPI.Account.Account
{
    public class FindResponse
    {
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public string USER_ID { get; set; }
    }
}
