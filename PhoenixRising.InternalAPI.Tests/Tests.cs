using System;
using System.Configuration;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;
using PhoenixRising.InternalAPI;
using PhoenixRising.InternalAPI.Account.Account;
using PhoenixRising.InternalAPI.Authentication;
using PhoenixRising.InternalAPI.Website;

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

            FindRequest request = new FindRequest(connection, "linternator");
            FindResponse response = request.Send();

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
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

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
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

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void SetStatus()
        {
            Guid user = new Guid("66e0db28-3fd9-6653-56dc-f02aaa393ab3");
            string accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjY2ZTBkYjI4LTNmZDktNjY1My01NmRjLWYwMmFhYTM5M2FiMyIsImV4cCI6MTUyNjE4MzM3NiwiaXNzIjoiYXBpLnZpc2lvbmFyeWdhbWVzLnh5eiIsImF1ZCI6InZpc2lvbmFyeWdhbWVzLnh5eiJ9.MkjbCQfonE33tCjxjYqheYkm3-he3Ow7YL0kaaGgUMw";
            int expiresTime = 12345678;
            string refreshToken = "refreshtokenhere";
            AuthenticationStore auth = new AuthenticationStore(user, accessToken, expiresTime, refreshToken);

            APIConnection connection = new APIConnection("https://pr-api-uks-dev.azurewebsites.net/v1");

            SetStatusRequest request = new SetStatusRequest(auth, connection, OnlineStatus.OFFLINE, GameStatus.INLOBBY);
            SetStatusResponse response = request.Send();

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

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
        
        [TestMethod]
        public void CreateUser()
        {
            APIConnection connection = new APIConnection("https://pr-api-uks-dev.azurewebsites.net/v1");
            CreateUserRequest request = new CreateUserRequest(connection);
            request.Email = "Knar.Knar@Knar.com";
            request.FirstName = "George";
            request.LastName = "Washington";
            request.Nicknane = "CherryTreeBoi";

            KeyVaultClient KeyVault;
            try
            {
                var azureServiceTokenProvider = new AzureServiceTokenProvider();
                var _token = azureServiceTokenProvider.GetAccessTokenAsync("https://vault.azure.net").Result;
                KeyVault = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            }
            catch (Exception e)
            {
                throw e;
            }
            var bundle = KeyVault.GetSecretAsync("https://pr-kv-uks-dev.vault.azure.net/secrets/AppConnectionKey").Result;
            request.AppAccessToken = bundle.Value;

            CreateUserResponse response = request.Send();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void ForgotPasswordRequest()
        {
            APIConnection connection = new APIConnection("https://pr-api-uks-dev.azurewebsites.net/v1");
            string email = "adKnar@comcast.net";
            RequestResetPasswordRequest request = new RequestResetPasswordRequest(connection, email);

            KeyVaultClient KeyVault;
            try
            {
                var azureServiceTokenProvider = new AzureServiceTokenProvider();
                var _token = azureServiceTokenProvider.GetAccessTokenAsync("https://vault.azure.net").Result;
                KeyVault = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            }
                catch (Exception e)
            {
                throw e;
            }
            var bundle = KeyVault.GetSecretAsync("https://pr-kv-uks-dev.vault.azure.net/secrets/AppConnectionKey").Result;
            request.AppAccessToken = bundle.Value;

            RequestResetPasswordResponse response = request.Send();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void ResetPassword()
        {
            APIConnection connection = new APIConnection("https://pr-api-uks-dev.azurewebsites.net/v1");
            string passwordToken = "";
            string password = "newPass";
            ResetPasswordRequest request = new ResetPasswordRequest(connection, passwordToken, password);

            ResetPasswordResponse response = request.Send();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        //TODO: Create Update Info

        //TODO: Create friend request tests

        //TODO: Create series of Account tests. Log into two account, send requests back and forth, make sure responses are as expected

        //TODO: Create test for reset password
    }
}
