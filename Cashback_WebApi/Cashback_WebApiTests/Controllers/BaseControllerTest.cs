using Cashback_WebApi.Helpers.Tests;
using Cashback_WebApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public bool IsAuthenticatedUsingToken
        {
            get => _token?.Autenticado ?? false;
        }

        public BaseControllerTest()
        {
            _client = HttpClientHelper.GetClient();
            var builder = new BuilderHelper();
            _emailAccesso = builder._configuration["API_Access:Email"];
            _senhaAccesso = builder._configuration["API_Access:Senha"];
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
    }
}
