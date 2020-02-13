using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cashback_WebApi.Helpers.Tests
{
    public class BuilderHelper
    {
        public IConfiguration _configuration;

        public BuilderHelper()
        {
            var location = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));

            var builder = new ConfigurationBuilder()
                            .SetBasePath(location)
                            .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }


    }
}
