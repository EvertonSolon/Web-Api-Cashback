using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cashback_WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Cashback_WebApi.ApiClients;
using Cashback_WebApi.Extensoes;
using Newtonsoft.Json;
using Cashback_WebApi.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Cashback_WebApi.Controllers.Tests
{
    [TestClass()]
    public class CompraControllerTests : BaseTest
    {
        [TestMethod()]
        public void TodasTest()
        {
            Autenticar();

            List<CompraModel> compras = null;

            if (AutenticadoComToken)
            {
                //ExecuteWithToken é um método de extensão que está na classe RetryPolicyExtensions, em Cashback_WebApi.Extensoes.
                var response = _jwtPolicy.ExecuteWithToken(_token, context =>
                {
                    var requestMessage = new HttpRequestMessage(HttpMethod.Get, "compra/todas");

                    requestMessage.Headers.Add("Authorization", $"Bearer {context["AccessToken"]}");
                    //requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context["AccessToken"].ToString());

                    var responseMessage = _client.SendAsync(requestMessage).Result;

                    return responseMessage;

                });

                if (response.IsSuccessStatusCode)
                {
                    var conteudo = response.Content.ReadAsStringAsync().Result;
                    compras = JsonConvert.DeserializeObject<List<CompraModel>>(conteudo);
                }
            }

            Assert.IsNotNull(compras);
        }
    }
}