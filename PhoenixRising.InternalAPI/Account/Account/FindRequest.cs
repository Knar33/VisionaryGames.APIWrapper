using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RestSharp;

namespace PhoenixRising.InternalAPI.Account.Account
{
    public class FindRequest
    {
        public FindRequest(string nickname, AuthenticationStore auth)
        {
            Nickname = nickname;
            Auth = auth;
        }

        public string Nickname { get; set; }

        public AuthenticationStore Auth { get; set; }

        public FindResponse Send()
        {
            var client = new RestClient("https://pr-api-uks-dev.azurewebsites.net");

            var request = new RestRequest("v1/account/find/{nickname}", Method.GET);
            request.AddHeader("X-Access-Token", Auth.AccessToken);
            request.AddUrlSegment("nickname", Nickname);
            
            var response = client.Execute<FindResponse>(request);
            return response.Data;
        }
    }
}
