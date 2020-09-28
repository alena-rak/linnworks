using System.Net;
using LinnworkTestTask.api.main;
using LinnworkTestTask.main.utils;
using NUnit.Framework;
using RestSharp;

namespace LinnworkTestTask.api.test
{
    [TestFixture]
    [Category("ApiTests")]
    public class LoginTest : AbstractApiTest
    {
        [Test]
        public void testApiLoginSuccessful()
        {
            JsonObject loginBody = new JsonObject();
            loginBody.Add("token", ConfigReader.GetLoginToken());
            Assert.AreEqual(HttpStatusCode.OK, RestAdapter.POST("/Auth/Login", loginBody).StatusCode,
                "Login with correct token was unsuccessful");
        }
        
        [Test]
        public void testApiLoginFailedForIncorrectToken()
        {
            JsonObject loginBody = new JsonObject();
            loginBody.Add("token", RandomStringUtil.RandomAlphaNumericString(12));
            Assert.AreEqual(HttpStatusCode.BadRequest, RestAdapter.POST("/Auth/Login", loginBody).StatusCode,
                "Login with wrong toked was successful");
        }
    }
}