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
    public class RevendedorControllerTests : BaseControllerTest
    {
        [TestMethod()]
        public void GetTest()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "revendedor");
            requestMessage.Content = new StringContent(
                                        JsonConvert.SerializeObject(
                                            new
                                            {
                                                Email = _emailAccesso,
                                                Senha = _senhaAccesso
                                            }), Encoding.UTF8, "application/json");

            var respToken = _client.SendAsync(requestMessage).Result;

            //if (respToken.IsSuccessStatusCode)
            //{
            //    var contentResult = response.Content.ReadAsStringAsync().Result;
            //    //var content = JsonConvert.DeserializeObject<List<Word>>(contentResult);
            //    //var content = contentResult;
            //    //return content;

            //    Assert.IsNotNull(contentResult);
            //}
        }
    }
}