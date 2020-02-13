using Cashback_WebApi.Helpers;
using Cashback_WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cashback_WebApi.ApiClients
{
    public class ApiClient
    {
        protected HttpClient _client;
        protected TokenModel _token;
        protected string _emailAccesso;
        protected string _senhaAccesso;
        protected HttpResponseMessage _responseMessage;

        public ApiClient()
        {
            _client = HttpClientHelper.GetClient_ApiAcumuladoCashback();
        }

        public AcumuladoCashback Get()
        {
            return null;
        }

        public void Autenticar()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "");
            //requestMessage.Content = new StringContent(
            //                            JsonConvert.SerializeObject(
            //                                new
            //                                {
            //                                    Email = _emailAccesso,
            //                                    Senha = _senhaAccesso
            //                                }), Encoding.UTF8, "application/json");

            _responseMessage = _client.SendAsync(requestMessage).Result;

            var conteudo = _responseMessage.Content.ReadAsStringAsync().Result;

            if (_responseMessage.IsSuccessStatusCode)
                _token = JsonConvert.DeserializeObject<TokenModel>(conteudo);
            else
                _token = null;
        }
    }
}
