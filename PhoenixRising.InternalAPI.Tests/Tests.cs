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
        public string testToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjU2NDhiOGU2LTgxNDQtNDI5NS1hMzJmLTQ1M2UzZjgxOTRjYSIsImV4cCI6MTUyNjI3MDMwNCwiaXNzIjoiYXBpLnZpc2lvbmFyeWdhbWVzLnh5eiIsImF1ZCI6InZpc2lvbmFyeWdhbWVzLnh5eiJ9.4dydL2-KWgbBWfN5WeQh4vKHRROJCSqgcVJC-aTkB5s";
        public Guid testUser = new Guid("5648b8e6-8144-4295-a32f-453e3f8194ca");

        [TestMethod]
        public void FindRequest()
        {
            APIConnection connection = new APIConnection("https://pr-api-uks-dev.azurewebsites.net/v1");

            FindRequest request = new FindRequest(connection, "Knar66");
            FindResponse response = request.Send();

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreEqual(response.USER_ID, "5648b8e6-8144-4295-a32f-453e3f8194ca");
        }

        [TestMethod]
        public void GetUserDetails()
        {
            Guid user = testUser;
            string accessToken = testToken;
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
            Guid user = testUser;
            string accessToken = testToken;
            int expiresTime = 12345678;
            string refreshToken = "refreshtokenhere";
            AuthenticationStore auth = new AuthenticationStore(user, accessToken, expiresTime, refreshToken);

            APIConnection connection = new APIConnection("https://pr-api-uks-dev.azurewebsites.net/v1");

            PingRequest request = new PingRequest(auth, connection);
            PingResponse response = request.Send();

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void SetStatus()
        {
            Guid user = testUser;
            string accessToken = testToken;
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

            LoginRequest request = new LoginRequest(connection, "adKnar@comcast.net", "newPass");
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
            request.Email = "adKnar@comcast.net";
            request.FirstName = "Knar";
            request.LastName = "Lhe";
            request.Nicknane = "Knar66";
            request.Password = "Password1!";

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
            string passwordToken = "TAQXLRouHTIMhcKdq9BoB27QnCWGfzMRNVXB4uWn8t0Rkoawhn";
            string password = "newPass";
            ResetPasswordRequest request = new ResetPasswordRequest(connection, passwordToken, password);

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

            ResetPasswordResponse response = request.Send();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void EditUser()
        {
            Guid user = testUser;
            string accessToken = testToken;
            int expiresTime = 12345678;
            string refreshToken = "refreshtokenhere";
            AuthenticationStore auth = new AuthenticationStore(user, accessToken, expiresTime, refreshToken);

            APIConnection connection = new APIConnection("https://pr-api-uks-dev.azurewebsites.net/v1");
            EditUserRequest request = new EditUserRequest(connection, auth);
            request.FirstName = "Knar2";
            request.LastName = "Lhe";
            request.Nicknane = "Knar66";
            request.Password = "Password1!";
            request.UserID = testUser;

            EditUserResponse response = request.Send();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        //TODO: parse userID response string from create user

        //TODO: create Change Account Permissions methods/tests

        //TODO: Always return content on response objects

        //TODO: parse object straight into Data
    }
}
