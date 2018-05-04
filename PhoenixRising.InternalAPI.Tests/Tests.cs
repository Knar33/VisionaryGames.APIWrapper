using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoenixRising.InternalAPI;
using PhoenixRising.InternalAPI.Account.Account;

namespace PhoenixRising.InternalAPI.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestMethod()
        {
            Guid user = new Guid("66e0db28-3fd9-6653-56dc-f02aaa393ab3");
            string accessToken = "accesstokenhere";
            int expiresTime = 12345678;
            string refreshToken = "refreshtokenhere";

            AuthenticationStore auth = new AuthenticationStore(user, accessToken, expiresTime, refreshToken);

            FindRequest request = new FindRequest(auth);
            FindResponse response = request.Send();
        }
    }
}
