using FinTech.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FinTech.Core.Tests
{
    public class BtcServiceTests
    {
        public BtcServiceTests()
        {
        }

        [Fact]
        public void BasicInfo()
        {
            var service = new BtcService(TestHelper.Configuration);

            service.LookupTransactionInfo("c7322fbe743b5d35951ca6abee71b8c8d2c3b8a606fce572f93a17ded3a4b60c");
        }
    }
}
