using System.Net;
using LinnworkTestTask.api.main;
using LinnworkTestTask.main.utils;
using RestSharp;
using RestSharp.Serialization.Json;

namespace LinnworkTestTask.api.test
{
    public abstract class AbstractApiTest
    {
        protected JsonDeserializer jsonDeserializer = new JsonDeserializer();
        public void DoApiLogin()
        {
            RestAdapter.Client.CookieContainer = new CookieContainer();
            JsonObject loginBody = new JsonObject();
            loginBody.Add("token", ConfigReader.GetLoginToken());
            RestAdapter.POST("/Auth/Login", loginBody);
        }
    }
}