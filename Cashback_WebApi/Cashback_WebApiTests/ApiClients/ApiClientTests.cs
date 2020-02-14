using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cashback_WebApi.ApiClients;
using System;
using System.Collections.Generic;
using System.Text;
using Cashback_WebApi.Models;

namespace Cashback_WebApi.ApiClients.Tests
{
    [TestClass()]
    public class ApiClientTests
    {
        [TestMethod()]
        public void Obter_AcumuladoCashbackTest()
        {
            var apiClient = new ApiClient();
            var acumuladoCashback = new AcumuladoCashback();

            var resultado = apiClient.Obter_AcumuladoCashback();

            Assert.IsInstanceOfType(resultado, typeof(AcumuladoCashback));
        }
    }
}