using FinTech.Core.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Core.Interfaces
{
    public interface ITransactionService
    {
        IList<Transaction> GetTransactions();
        Transaction GetTransactionById(string id);
        void DeleteTransaction(string id);
        void UpdateTransaction(string id, Transaction transaction);
        Transaction AddTransaction(Transaction transaction);

        FileStream ExportTransactions();

        double TotalAmount(string accountId, CryptoCurrencyType currencyType = CryptoCurrencyType.BitCoin);
        void CreateTransaction(Transaction transaction);
    }
}
