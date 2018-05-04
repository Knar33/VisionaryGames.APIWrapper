using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixRising.InternalAPI.Account.Account
{
    public class FindRequest
    {
        public FindRequest(AuthenticationStore auth)
        {

        }

        public AuthenticationStore Auth { get; set; }

        public FindResponse Send()
        {
            return new FindResponse();
        }
    }
}
