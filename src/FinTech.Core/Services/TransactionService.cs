using FinTech.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinTech.Core.Models;
using System.IO;
using MongoDB.Driver;
using Microsoft.Framework.Configuration;
using MongoDB.Bson;

namespace FinTech.Core.Services
{
    public class TransactionService : ITransactionService
    {
        public IConfiguration Configuration { get; set; }

        public TransactionService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Transaction AddTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public void CreateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteTransaction(string id)
        {
            throw new NotImplementedException();
        }

        public FileStream ExportTransactions()
        {
            throw new NotImplementedException();
        }

        public Transaction GetTransactionById(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Transaction> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public double TotalAmount(string accountId, CryptoCurrencyType currencyType = CryptoCurrencyType.BitCoin)
        {
            throw new NotImplementedException();
        }

        public void UpdateTransaction(string id, Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
