using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Framework.Configuration;

namespace FinTech.Core.Tests
{
    public static class TestHelper
    {
        private static IConfiguration _configuration = null;
        public static IConfiguration Configuration {
            get
            {
                if(_configuration == null)
                {
                    var configPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..");
                    _configuration = new ConfigurationBuilder(configPath).AddJsonFile("config.json").Build();
                }
                return _configuration;
            }
        }
    }
}
