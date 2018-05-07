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
            string accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjY2ZTBkYjI4LTNmZDktNjY1My01NmRjLWYwMmFhYTM5M2FiMyIsImV4cCI6MTUyMDY5NjcxMSwiaXNzIjoiYXBpLnZpc2lvbmFyeWdhbWVzLnh5eiIsImF1ZCI6InZpc2lvbmFyeWdhbWVzLnh5eiJ9.Hb193v4bDX78YVvYH-qvYGN0JAPOeGAqWiAKf4H80a0";
            int expiresTime = 12345678;
            string refreshToken = "refreshtokenhere";
            AuthenticationStore auth = new AuthenticationStore(user, accessToken, expiresTime, refreshToken);

            FindRequest request = new FindRequest("linternator", auth);
            FindResponse response = request.Send();
        }



    }
}
