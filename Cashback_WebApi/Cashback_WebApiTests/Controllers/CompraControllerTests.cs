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
        public void Obter_Todas_Vendas_Com_Sucesso_Test()
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

        [TestMethod()]
        public void Cadastrar_Nova_Compra_Com_Cpf_Generico_E_Valor_1500_Sucesso_Test()
        {
            Autenticar();

            var compraDto = new CompraDto
            {
                CodigoCompra = "R14B96E17",
                Valor = 1500.00,
                DataCompra = DateTime.Parse("2020-02-14"),
                CpfRevendedor = "123.123.123-23"
            };

            CompraModel compra = null;

            if (AutenticadoComToken)
            {
                //ExecuteWithToken é um método de extensão que está na classe RetryPolicyExtensions, em Cashback_WebApi.Extensoes.
                var response = _jwtPolicy.ExecuteWithToken(_token, context =>
                {
                    var requestMessage = new HttpRequestMessage(HttpMethod.Post, "compra")
                    {
                        Content = new StringContent(
                                        JsonConvert.SerializeObject(compraDto), Encoding.UTF8, "application/json")
                    };

                    requestMessage.Headers.Add("Authorization", $"Bearer {context["AccessToken"]}");

                    var responseMessage = _client.SendAsync(requestMessage).Result;

                    return responseMessage;

                });

                if (response.IsSuccessStatusCode)
                {
                    var conteudo = response.Content.ReadAsStringAsync().Result;
                    compra = JsonConvert.DeserializeObject<CompraModel>(conteudo);
                }
            }

            Assert.IsNotNull(compra);
        }

        [TestMethod()]
        public void Atualizar_Valor_Compra_Cashback_Sucesso_Test()
        {
            Autenticar();

            var compraDto = new CompraDto
            {
                CodigoCompra = "R14B96E17",
                Valor = 1500.1,
                DataCompra = DateTime.Parse("2020-02-14"),
                CpfRevendedor = "123.123.123-23"
            };

            CompraModel compra = null;

            if (AutenticadoComToken)
            {
                //ExecuteWithToken é um método de extensão que está na classe RetryPolicyExtensions, em Cashback_WebApi.Extensoes.
                var response = _jwtPolicy.ExecuteWithToken(_token, context =>
                {
                    var requestMessage = new HttpRequestMessage(HttpMethod.Put, "compra/8")
                    {
                        Content = new StringContent(
                                        JsonConvert.SerializeObject(compraDto), Encoding.UTF8, "application/json")
                    };

                    requestMessage.Headers.Add("Authorization", $"Bearer {context["AccessToken"]}");

                    var responseMessage = _client.SendAsync(requestMessage).Result;

                    return responseMessage;

                });

                if (response.IsSuccessStatusCode)
                {
                    var conteudo = response.Content.ReadAsStringAsync().Result;
                    compra = JsonConvert.DeserializeObject<CompraModel>(conteudo);
                }
            }

            double cashbackAtualizado = 300.02;

            Assert.IsTrue(compra.Cashback == cashbackAtualizado);
        }
    }
}