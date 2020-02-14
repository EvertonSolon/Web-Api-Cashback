using Cashback_WebApi.Helpers;
using Cashback_WebApi.Models;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cashback_WebApi.Extensoes;

namespace Cashback_WebApi.ApiClients
{
    public class ApiClient
    {
        private HttpClient _client;

        public ApiClient()
        {
            _client = HttpClientHelper.GetClient_ApiAcumuladoCashback();
        }

        public AcumuladoCashback Obter_AcumuladoCashback()
        {
            var acumuladoCashback = new AcumuladoCashback();

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "");

            var responseMessage = _client.SendAsync(requestMessage).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                string conteudo = requestMessage.Content.ReadAsStringAsync().Result;
                acumuladoCashback = JsonConvert.DeserializeObject<AcumuladoCashback>(conteudo);
            }

            return acumuladoCashback;
        }
    }
}
