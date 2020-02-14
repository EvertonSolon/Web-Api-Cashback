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
        private TokenModel _token;
        //private string _emailAccesso;
        //private string _senhaAccesso;
        private HttpResponseMessage _responseMessage;
        private RetryPolicy<HttpResponseMessage> _jwtPolicy;

        public ApiClient()
        {
            _token = new TokenModel
            {
                Token = "ZXPURQOARHiMc6Y0flhRC1LVlZQVFRnm"
            };
            _client = HttpClientHelper.GetClient_ApiAcumuladoCashback();
            _jwtPolicy = CreateAccessTokenPolicy();
        }

        public bool AutenticadoComToken
        {
            get => _token?.Autenticado ?? false;
        }

        public AcumuladoCashback Obter_AcumuladoCashback()
        {
            var acumuladoCashback = new AcumuladoCashback();

            //ExecuteWithToken é um método de extensão que está na classe RetryPolicyExtensions, em Cashback_WebApi.Extensoes.
            var response = _jwtPolicy.ExecuteWithToken(_token, context =>
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, "");

                requestMessage.Headers.Add("Authorization", $"Bearer {context["AccessToken"]}");

                var responseMessage = _client.SendAsync(requestMessage).Result;

                return responseMessage;

            });

            if(response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                acumuladoCashback = JsonConvert.DeserializeObject<AcumuladoCashback>(conteudo);
            }

            return acumuladoCashback;
        }

        public void Autenticar()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "login");
            requestMessage.Content = new StringContent(
                                        JsonConvert.SerializeObject(
                                            new
                                            {
                                                //Email = _emailAccesso,
                                                //Senha = _senhaAccesso
                                            }), Encoding.UTF8, "application/json");

            _responseMessage = _client.SendAsync(requestMessage).Result;

            var conteudo = _responseMessage.Content.ReadAsStringAsync().Result;

            if (_responseMessage.IsSuccessStatusCode)
                _token = JsonConvert.DeserializeObject<TokenModel>(conteudo);
            else
                _token = null;
        }

        private RetryPolicy<HttpResponseMessage> CreateAccessTokenPolicy()
        {
            var policy = Policy.HandleResult<HttpResponseMessage>(
                            message => message.StatusCode == HttpStatusCode.Unauthorized)
                            .Retry(1, (message, retryCount, context) =>
                            {
                                Autenticar();
                                if (!(_token?.Autenticado ?? false))
                                    throw new InvalidOperationException("Token inválido!");

                                context["AccessToken"] = _token.Autenticado;
                            });

            return policy;
        }
    }
}
