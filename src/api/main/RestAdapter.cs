using System;
using LinnworkTestTask.main.utils;
using RestSharp;

namespace LinnworkTestTask.api.main
{
    public class RestAdapter
    {
        private static RestClient client = new RestClient(ConfigReader.GetAppUrl()+ "/api");

        public static RestClient Client
        {
            get => client;
            set => client = value;
        }

        public static IRestResponse GET(String resource)
        {
            Logger.Info(String.Format("executing GET request to {0}", resource));
            var request = new RestRequest(resource);
            request.RequestFormat = DataFormat.Json;
            return client.Execute(request, Method.GET);
        }

        public static IRestResponse POST(String resource, JsonObject body)
        {
            Logger.Info(String.Format("executing POST request to {0}\n {1}", resource, body));
            var request = new RestRequest(resource, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(body);
            return client.Execute(request, Method.POST);
        }

        public static IRestResponse PUT(String resource, JsonObject body)
        {
            Logger.Info(String.Format("executing PUT request to {0}\n {1}", resource, body));
            return client.Execute(new RestRequest(resource), Method.PUT);
        }
        
        public static IRestResponse DELETE(String resource)
        {
            Logger.Info(String.Format("executing DELETE request to {0}", resource));
            return client.Execute(new RestRequest(resource), Method.DELETE);
        }
    }
}