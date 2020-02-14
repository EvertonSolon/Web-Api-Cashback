using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cashback_WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace Cashback_WebApi.Controllers.Tests
{
    [TestClass()]
    public class LoginControllerTests : BaseTest
    {
        [TestMethod()]
        public void Login_Sucesso_Test()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "login");
            requestMessage.Content = new StringContent(
                                        JsonConvert.SerializeObject(
                                            new
                                            {
                                                Email = _emailAccesso,
                                                Senha = _senhaAccesso
                                            }), Encoding.UTF8, "application/json");

            var respToken = _client.SendAsync(requestMessage).Result;

            Assert.IsTrue(respToken.IsSuccessStatusCode);
        }

        [TestMethod()]
        public void Login_Obter_Token_Sucesso_Test()
        {
            Autenticar();

            Assert.IsTrue(AutenticadoComToken);
        }

        [TestMethod()]
        public void Login_Com_Usuario_Incorreto_Falha_Test()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "login");
            requestMessage.Content = new StringContent(
                                        JsonConvert.SerializeObject(
                                            new
                                            {
                                                Email = _emailAccesso + ".br", //Inseri o .br para falhar a 
                                                Senha = _senhaAccesso
                                            }), Encoding.UTF8, "application/json");

            var respToken = _client.SendAsync(requestMessage).Result;

            Assert.IsFalse(respToken.IsSuccessStatusCode);
        }

    }
}