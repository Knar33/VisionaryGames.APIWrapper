using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Friends
{
    class GetFriendsResponse
    {
        public GetFriendsResponse(IRestResponse<GetFriendsResponse> res)
        {
            StatusCode = res.StatusCode;
            if (res.StatusCode == HttpStatusCode.OK)
            {
                BLOCKED = res.Data.BLOCKED;
                FRIENDS = res.Data.FRIENDS;
                PENDING = res.Data.PENDING;
                REJECTED = res.Data.REJECTED;
            }
            else
            {
                Content = res.Content;
            }
        }

        public GetFriendsResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        
        public Blocked[] BLOCKED { get; set; }
        public Friend[] FRIENDS { get; set; }
        public Pending[] PENDING { get; set; }
        public Rejected[] REJECTED { get; set; }

        public class Blocked
        {
            public string NICKNAME { get; set; }
            public string USERID { get; set; }
        }

        public class Friend
        {
            public string NICKNAME { get; set; }
            public string USERID { get; set; }
            public string STATUS { get; set; }
            public string GAME_STATUS { get; set; }
        }

        public class Pending
        {
            public string NICKNAME { get; set; }
            public string USERID { get; set; }
        }

        public class Rejected
        {
            public string NICKNAME { get; set; }
            public string USERID { get; set; }
        }
    }
}
