using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Cashback_WebApi.Helpers.Tests
{
    public class HttpClientHelper
    {
        public static HttpClient GetClient()
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
    }
}
