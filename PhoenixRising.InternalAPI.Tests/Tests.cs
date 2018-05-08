using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoenixRising.InternalAPI;
using PhoenixRising.InternalAPI.Account.Account;
using PhoenixRising.InternalAPI.Authentication;

namespace PhoenixRising.InternalAPI.Tests
{
    [TestClass]
    public class Tests
    {
        //TODO: Make these tests actually useful
        [TestMethod]
        public void FindRequest()
        {
            APIConnection connection = new APIConnection("https://pr-api-uks-dev.azurewebsites.net/v1");

            FindRequest request = new FindRequest(connection, "linternatora");
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

            APIConnection connection = new APIConnection("https://pr-api-uks-dev.azurewebsites.net/v1");

            GetUserDetailsRequest request = new GetUserDetailsRequest(auth, connection);
            GetUserDetailsResponse response = request.Send();
        }

        [TestMethod]
        public void Ping()
        {
            Guid user = new Guid("46e0db28-3fd9-6653-56dc-f02aaa393ab3");
            string accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjY2ZTBkYjI4LTNmZDktNjY1My01NmRjLWYwMmFhYTM5M2FiMyIsImV4cCI6MTUyNTY2NjE5NSwiaXNzIjoiYXBpLnZpc2lvbmFyeWdhbWVzLnh5eiIsImF1ZCI6InZpc2lvbmFyeWdhbWVzLnh5eiJ9.lo-rrtCA052Dl476nO9UNldYzd3VcEVEegSZHWyHJyc";
            int expiresTime = 12345678;
            string refreshToken = "refreshtokenhere";
            AuthenticationStore auth = new AuthenticationStore(user, accessToken, expiresTime, refreshToken);

            APIConnection connection = new APIConnection("https://pr-api-uks-dev.azurewebsites.net/v1");

            GetUserDetailsRequest request = new GetUserDetailsRequest(auth, connection);
            GetUserDetailsResponse response = request.Send();
        }

        //TODO: Create SetStatus test

        [TestMethod]
        public void Login()
        {
            APIConnection connection = new APIConnection("https://pr-api-uks-dev.azurewebsites.net/v1");

            LoginRequest request = new LoginRequest(connection, "test@test.com", "test");
            LoginResponse response = request.Send();

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void Refresh()
        {
            APIConnection connection = new APIConnection("https://pr-api-uks-dev.azurewebsites.net/v1");
            LoginRequest request = new LoginRequest(connection, "test@test.com", "test");
            LoginResponse response = request.Send();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            AuthenticationStore auth = new AuthenticationStore(response);

            RefreshRequest request2 = new RefreshRequest(auth, connection);
            RefreshResponse response2 = request2.Send();
            Assert.AreEqual(response2.StatusCode, System.Net.HttpStatusCode.OK);
        }

        //TODO: Create series of Account tests. Log into two account, send requests back and forth, make sure responses are as expected
    }
}
