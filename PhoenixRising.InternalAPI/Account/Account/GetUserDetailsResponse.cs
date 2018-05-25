using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Account
{
    public class GetUserDetailsResponse
    {
        public GetUserDetailsResponse(IRestResponse<GetUserDetailsResponse> res)
        {
            StatusCode = res.StatusCode;
            Content = res.Content;
            if (res.StatusCode == HttpStatusCode.OK)
            {
                NICKNAME = res.Data.NICKNAME;
                FIRST_NAME = res.Data.FIRST_NAME;
                LAST_NAME = res.Data.LAST_NAME;
                EMAIL = res.Data.EMAIL;
                CURRENCY_AMOUNT = res.Data.CURRENCY_AMOUNT;
                IS_GAME_DEV = res.Data.IS_GAME_DEV;
                LEVEL = res.Data.LEVEL;
                CURRENCY_AMOUNT_2 = res.Data.CURRENCY_AMOUNT_2;
                ONLINE_STATUS = res.Data.ONLINE_STATUS;
                GAME_STATUS = res.Data.GAME_STATUS;
                PERMISSIONS = new Permissions
                {
                    Developer = res.Data.PERMISSIONS.Developer,
                    Administrator = res.Data.PERMISSIONS.Administrator,
                    Banned = res.Data.PERMISSIONS.Banned,
                    CommunityManager = res.Data.PERMISSIONS.CommunityManager
                };
            }
        }

        public GetUserDetailsResponse()
        {

        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode {get; set;}

        public string NICKNAME { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string EMAIL { get; set; }
        public string CURRENCY_AMOUNT { get; set; }
        public string IS_GAME_DEV { get; set; }
        public string IS_GAME_ADMIN { get; set; }
        public string LEVEL { get; set; }
        public string CURRENCY_AMOUNT_2 { get; set; }
        public string ONLINE_STATUS { get; set; }
        public string GAME_STATUS { get; set; }
        public Permissions PERMISSIONS { get; set; }
    }

    public class Permissions
    {
        public bool Developer { get; set; }
        public bool Administrator { get; set; }
        public bool CommunityManager { get; set; }
        public bool Banned { get; set; }
    }
}
