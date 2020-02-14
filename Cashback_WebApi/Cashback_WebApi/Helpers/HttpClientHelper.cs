using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Cashback_WebApi.Helpers
{
    public static class HttpClientHelper
    {
        public static HttpClient GetClient_Local()
        {
            var client = GerarClient("API_Access:UrlBase");

            return client;
        }

        public static HttpClient GetClient_ApiAcumuladoCashback()
        {
            var client = GerarClient("API_AcumuladoCashBack:Url");

            return client;
        }

        private static HttpClient GerarClient(string appSettgins)
        {
            var uriApi = new BuilderHelper()._configuration[appSettgins];

            var client = new HttpClient
            {
                BaseAddress = new Uri(uriApi)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
