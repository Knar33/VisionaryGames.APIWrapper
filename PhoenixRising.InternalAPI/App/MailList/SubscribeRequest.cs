using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PhoenixRising.InternalAPI.App.MailList
{
    public class SubscribeRequest
    {
        public SubscribeRequest(string connection, string appAccessToken, string email)
        {
            Connection = connection;
            AppAccessToken = appAccessToken;
            email = Email;
        }

        public string Connection { get; set; }
        public string AppAccessToken { get; set; }
        public string Email { get; set; }

        public SubscribeResponse Send()
        {
            RestClient client = new RestClient(Connection);
            RestRequest request = new RestRequest("app/mail/subscribe", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { Email });
            request.AddHeader("App-Access-Token", AppAccessToken);

            var res = client.Execute<SubscribeResponse>(request);

            return new SubscribeResponse(res);
        }
    }
}
