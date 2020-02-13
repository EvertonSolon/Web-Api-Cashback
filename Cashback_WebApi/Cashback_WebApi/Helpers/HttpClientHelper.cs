using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Cashback_WebApi.Helpers
{
    public class HttpClientHelper
    {
        public static HttpClient GetClient_Local()
        {
            var uriApi = new BuilderHelper()._configuration["API_Access:UrlBase"];

            var client = new HttpClient
            {
                BaseAddress = new Uri(uriApi)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public static HttpClient GetClient_ApiAcumuladoCashback()
        {
            var uriApiWord = new BuilderHelper()._configuration["API_AcumuladoCashback:Url"];

            var client = new HttpClient
            {
                BaseAddress = new Uri(uriApiWord)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

    }
}
