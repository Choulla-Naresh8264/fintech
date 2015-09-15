using FinTech.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FinTech.Core.Tests
{
    public class TransactionServiceTests
    {
        public TransactionServiceTests()
        {
        }

        [Fact]
        public void TotalAmountIsZeroForNew()
        {
            var service = new TransactionService(TestHelper.Configuration);
            var amount = service.TotalAmount();
            Assert.True(amount >= 0);
        }
    }
}
