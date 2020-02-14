//using Cashback_WebApi.Helpers.Tests;
using Cashback_WebApi.Extensoes;
using Cashback_WebApi.Helpers;
using Cashback_WebApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Cashback_WebApi.Controllers.Tests
{
    public class BaseControllerTest
    {
        protected HttpClient _client;
        protected TokenModel _token;
        protected string _emailAccesso;
        protected string _senhaAccesso;
        protected HttpResponseMessage _responseMessage;
        private RetryPolicy<HttpResponseMessage> _jwtPolicy;

        public bool IsAuthenticatedUsingToken
        {
            get => _token?.Autenticado ?? false;
        }

        public BaseControllerTest()
        {
            _client = HttpClientHelper.GetClient_Local();
            var builder = new BuilderHelper();
            _emailAccesso = builder._configuration["API_Access:Email"];
            _senhaAccesso = builder._configuration["API_Access:Senha"];
        }

        public bool AutenticadoComToken
        {
            get => _token?.Autenticado ?? false;
        }

        public void Autenticar()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "login");
            requestMessage.Content = new StringContent(
                                        JsonConvert.SerializeObject(
                                            new
                                            {
                                                Email = _emailAccesso,
                                                Senha = _senhaAccesso
                                            }), Encoding.UTF8, "application/json");

            _responseMessage = _client.SendAsync(requestMessage).Result;

            var conteudo = _responseMessage.Content.ReadAsStringAsync().Result;

            if (_responseMessage.IsSuccessStatusCode)
                _token = JsonConvert.DeserializeObject<TokenModel>(conteudo);
            else
                _token = null;
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

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                acumuladoCashback = JsonConvert.DeserializeObject<AcumuladoCashback>(conteudo);
            }

            return acumuladoCashback;
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
