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
using PhoenixRising.InternalAPI.Administration.AccountAdmin;

namespace PhoenixRising.InternalAPI.Tests
{
    [TestClass]
    public class Tests
    {
        string connection = "https://pr-api-uks-dev.azurewebsites.net/v1";
        public string testToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjY2ZTBkYjI4LTNmZDktNjY1My01NmRjLWYwMmFhYTM5M2FiMyIsImV4cCI6MTUyNzIyMjE4NSwiaXNzIjoiYXBpLnZpc2lvbmFyeWdhbWVzLnh5eiIsImF1ZCI6InZpc2lvbmFyeWdhbWVzLnh5eiJ9.6dYztUvtbH3mEKJPZanx9SGVpWV0nZ3mw1UVuGPirkw";
        public Guid testUser = new Guid("66e0db28-3fd9-6653-56dc-f02aaa393ab3");

        [TestMethod]
        public void FindRequest()
        {
            FindRequest request = new FindRequest(connection, "Knar66");
            FindResponse response = request.Send();

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreEqual(response.USER_ID, "6d9d9295-b538-47e4-b213-e039658a8e8b");
        }

        [TestMethod]
        public void GetUserDetails()
        {
            GetUserDetailsRequest request = new GetUserDetailsRequest(connection, testToken, testUser);
            GetUserDetailsResponse response = request.Send();

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void Ping()
        {
            PingRequest request = new PingRequest(connection, testToken, testUser);
            PingResponse response = request.Send();

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        //Must actually
        [TestMethod]
        public void SetStatus()
        {
            SetStatusRequest request = new SetStatusRequest(connection, testToken, testUser, OnlineStatus.OFFLINE, GameStatus.INLOBBY);
            SetStatusResponse response = request.Send();

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        //must not be able to log into newly registered account without first verifying
        //must not be able to log into account whose password changed using the new email, without first verifying
        //must be able to log in using the old email after changing, until verifying new email
        [TestMethod]
        public void Login()
        {
            LoginRequest request = new LoginRequest(connection, "test@test.com", "test");
            LoginResponse response = request.Send();

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void Refresh()
        {
            LoginRequest request = new LoginRequest(connection, "test@test.com", "test");
            LoginResponse response = request.Send();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            
            RefreshRequest request2 = new RefreshRequest(connection, response.refresh_token);
            RefreshResponse response2 = request2.Send();
            Assert.AreEqual(response2.StatusCode, System.Net.HttpStatusCode.OK);
        }
        
        //must not be able to create the same email or nickname as an existing
        [TestMethod]
        public void CreateUser()
        {
            CreateUserRequest request = new CreateUserRequest(connection, testToken);
            request.Email = "adKnar@comcast.net";
            request.FirstName = "Knar";
            request.LastName = "Lhe";
            request.Nicknane = "Knar666";
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
            RequestResetPasswordRequest request = new RequestResetPasswordRequest(connection, testToken, "knarrr@gmail.com");

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

        //old password must be valid until new one is set
        [TestMethod]
        public void ResetPassword()
        {
            string passwordToken = "qefh2FdMZAgMg0g7dcqbmUn8XOaTEJYFop3D1V7cSMX2J1LeXZ";
            string password = "newPass";

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
            string appAccessToken = bundle.Value;
            ResetPasswordRequest request = new ResetPasswordRequest(connection, appAccessToken, passwordToken, password);
            
            ResetPasswordResponse response = request.Send();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        //must be able to send 1 of these values alone
        //must be able to send email along with other parameters, and get change verification email
        [TestMethod]
        public void EditUser()
        {
            EditUserRequest request = new EditUserRequest(connection, testToken, testUser);
            request.FirstName = "Knar2";
            request.LastName = "Lhe";
            request.Nicknane = "Knar66";

            EditUserResponse response = request.Send();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void UpdateUserPermissions()
        {
            UpdateUserPermissionsRequest request = new UpdateUserPermissionsRequest(connection, testToken, testUser);
            request.Administrator = 1;
            request.Banned = 0;
            request.Developer = 1;
            request.CommunityManager = 1;

            UpdateUserPermissionsResponse response = request.Send();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void ChangePassword()
        {
            string oldPassword = "password";
            string newPassword = "passy";
            ChangePasswordRequest request = new ChangePasswordRequest(connection, testToken, testUser, oldPassword, newPassword);

            ChangePasswordResponse response = request.Send();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        //must send email
        [TestMethod]
        public void ChangeEmail()
        {
            EditUserRequest request = new EditUserRequest(connection, testToken, testUser);
            request.Email = "superfakeemail134123w45pj3mn45k8j2b3452234@gmail.com";
            request.Password = "test";

            EditUserResponse response = request.Send();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void VerifyUser()
        {
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
            string appAccessToken = bundle.Value;

            string resetToken = "ThClkDquzDXMLQ1tVJvpUCkBxg2RQOG0ilNuu6BZj4IKI0sCam";
            VerifyUserRequest request = new VerifyUserRequest(connection, appAccessToken, resetToken);


            VerifyUserResponse response = request.Send();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void ResendValidation()
        {
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
            string appAccessToken = bundle.Value;

            string email = "Knar.Knar@Knar.com";
            ResendVerificationRequest request = new ResendVerificationRequest(connection, appAccessToken, email);
            ResendVerificationResponse response = request.Send();

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }
    }
}
