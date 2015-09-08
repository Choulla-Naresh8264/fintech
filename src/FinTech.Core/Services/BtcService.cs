using FinTech.Core.Interfaces;
using FinTech.Core.Models;
using Info.Blockchain.API.BlockExplorer;
using Microsoft.Framework.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoFlo.Core.Helpers;

namespace FinTech.Core.Services
{
    public class BtcService: IBtcService
    {
        public IConfiguration Configuration { get; set; }

        public BtcService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Models.Transaction LookupTransactionInfo(string transactionId)
        {
            if (string.IsNullOrEmpty(transactionId))
            {
                throw new ArgumentException("Invalid Transaction Id");
            }
            var blockExplorer = new BlockExplorer();

            var tx = Retry.Do<Info.Blockchain.API.BlockExplorer.Transaction>(() => { return blockExplorer.GetTransaction(transactionId); }, new TimeSpan(0, 0, 2));
             
            var result = new Models.Transaction {
                TransactionId = transactionId,
                Amount = (double)tx.Inputs.FirstOrDefault()?.PreviousOutput.Value/1000000,
                FromAddress = tx.Inputs.FirstOrDefault()?.PreviousOutput.Address,
                ToAddress = tx.Outputs.FirstOrDefault()?.Address,
                CurrencyType = CryptoCurrencyType.BitCoin,
                Timestamp = DateTime.Now };
            return result;
        }
    }
}
