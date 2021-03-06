﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Website
{
    public class ResetPasswordRequest
    {
        public ResetPasswordRequest(string connection, string appAccessToken, string passwordToken, string password)
        {
            Connection = connection;
            AppAccessToken = appAccessToken;
            PasswordToken = passwordToken;
            Password = password;
        }

        public string PasswordToken { get; set; }
        public string Password { get; set; }
        public string Connection { get; set; }
        public string AppAccessToken { get; set; }

        public ResetPasswordResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("app/account/passwd/{token}", Method.POST);
            request.AddUrlSegment("token", PasswordToken);
            request.AddHeader("App-Access-Token", AppAccessToken);
            request.AddHeader("Password", Password);

            var res = client.Execute<ResetPasswordResponse>(request);

            return new ResetPasswordResponse(res);
        }
    }
}
