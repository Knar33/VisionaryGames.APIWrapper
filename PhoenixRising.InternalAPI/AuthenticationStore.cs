using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoenixRising.InternalAPI.Authentication;

namespace PhoenixRising.InternalAPI
{
    public class AuthenticationStore
    {
        public AuthenticationStore()
        {
        }

        public AuthenticationStore(Guid userID, string accessToken, int expiresTime, string refreshToken)
        {
            UserID = userID;
            AccessToken = accessToken;
            ExpireTime = expiresTime;
            RefreshToken = refreshToken;
        }

        public AuthenticationStore(LoginResponse response)
        {
            UserID = new Guid(response.user_id);
            AccessToken = response.access_token;
            ExpireTime = Convert.ToInt32(response.expireTime);
            RefreshToken = response.refresh_token;
        }

        public Guid UserID { get; set; }
        public string AccessToken { get; set; }
        public int ExpireTime { get; set; }
        public string RefreshToken { get; set; }
    }
}
