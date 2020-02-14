using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cashback_WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Cashback_WebApi.ApiClients;

namespace Cashback_WebApi.Controllers.Tests
{
    [TestClass()]
    public class CompraControllerTests
    {
        private readonly ApiClient _apiClient;

        public CompraControllerTests()
        {
            _apiClient = new ApiClient();
        }

        //[TestMethod()]
        //public void TodasTest()
        //{
        //    _apiClient.Autenticar();

        //    if (!_apiClient.AutenticadoComToken)
        //        return Unauthorized();

        //    Assert.Fail();
        //}
    }
}