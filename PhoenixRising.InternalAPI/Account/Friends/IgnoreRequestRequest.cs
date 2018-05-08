﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Friends
{
    class IgnoreRequestRequest
    {
        public IgnoreRequestRequest(AuthenticationStore auth, APIConnection connection)
        {
            Auth = auth;
            Connection = connection;
            UserID = auth.UserID;
        }

        public Guid UserID { get; set; }
        public AuthenticationStore Auth { get; set; }
        public APIConnection Connection { get; set; }
        public Guid IDFriend { get; set; }

        public IgnoreRequestResponse Send()
        {
            RestClient client = new RestClient(Connection.URL);
            RestRequest request = new RestRequest("account/{userID}/friends/request/ignore", Method.POST);
            request.AddHeader("X-Access-Token", Auth.AccessToken);
            request.AddHeader("ID-Friend", IDFriend.ToString());
            request.AddUrlSegment("userID", UserID);

            var res = client.Execute<IgnoreRequestResponse>(request);

            return new IgnoreRequestResponse(res);
        }
    }
}
