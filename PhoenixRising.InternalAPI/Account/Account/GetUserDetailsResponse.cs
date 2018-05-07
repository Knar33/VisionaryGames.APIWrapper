using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace PhoenixRising.InternalAPI.Account.Account
{
    public class GetUserDetailsResponse
    {
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
    }
}
