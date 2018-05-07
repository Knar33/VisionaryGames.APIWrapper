using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoenixRising.InternalAPI;
using PhoenixRising.InternalAPI.Account.Account;

namespace PhoenixRising.InternalAPI.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void FindRequest()
        {
            Guid user = new Guid("66e0db28-3fd9-6653-56dc-f02aaa393ab3");
            string accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjY2ZTBkYjI4LTNmZDktNjY1My01NmRjLWYwMmFhYTM5M2FiMyIsImV4cCI6MTUyMDY5NjcxMSwiaXNzIjoiYXBpLnZpc2lvbmFyeWdhbWVzLnh5eiIsImF1ZCI6InZpc2lvbmFyeWdhbWVzLnh5eiJ9.Hb193v4bDX78YVvYH-qvYGN0JAPOeGAqWiAKf4H80a0";
            int expiresTime = 12345678;
            string refreshToken = "refreshtokenhere";
            AuthenticationStore auth = new AuthenticationStore(user, accessToken, expiresTime, refreshToken);

            APIConnection connection = new APIConnection("https://pr-api-uks-dev.azurewebsites.net");

            FindRequest request = new FindRequest(auth, connection, "linterator");
            FindResponse response = request.Send();
        }

        [TestMethod]
        public void GetUserDetails()
        {
            Guid user = new Guid("46e0db28-3fd9-6653-56dc-f02aaa393ab3");
            string accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjY2ZTBkYjI4LTNmZDktNjY1My01NmRjLWYwMmFhYTM5M2FiMyIsImV4cCI6MTUyNTY2NjE5NSwiaXNzIjoiYXBpLnZpc2lvbmFyeWdhbWVzLnh5eiIsImF1ZCI6InZpc2lvbmFyeWdhbWVzLnh5eiJ9.lo-rrtCA052Dl476nO9UNldYzd3VcEVEegSZHWyHJyc";
            int expiresTime = 12345678;
            string refreshToken = "refreshtokenhere";
            AuthenticationStore auth = new AuthenticationStore(user, accessToken, expiresTime, refreshToken);

            APIConnection connection = new APIConnection("https://pr-api-uks-dev.azurewebsites.net");

            GetUserDetailsRequest request = new GetUserDetailsRequest(auth, connection);
            GetUserDetailsResponse response = request.Send();
        }
    }
}
