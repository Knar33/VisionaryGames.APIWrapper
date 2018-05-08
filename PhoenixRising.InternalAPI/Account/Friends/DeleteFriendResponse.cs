using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Friends
{
    class DeleteFriendResponse
    {
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
