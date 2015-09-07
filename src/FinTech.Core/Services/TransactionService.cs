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
    public class TransactionService: ITransactionService
    {
        public const string TRANSACTION_COLLECTION_NAME = "transactions";
        public IConfiguration Configuration { get; set; }

        public TransactionService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IMongoDatabase _db;
        private IMongoCollection<Transaction> TransactionCollection
        {
            get
            {
                if (_db == null)
                {
                    var connectionString = Configuration.GetSection("Data:DefaultConnection:MongoConnectionString");
                    var client = new MongoClient(connectionString?.Value);

                    var database = Configuration.GetSection("Data:DefaultConnection:MongoDatabase");
                    _db = client.GetDatabase(database?.Value);
                }
                return _db.GetCollection<Transaction>(TRANSACTION_COLLECTION_NAME);
            }
        }


        public Transaction AddTransaction(Transaction transaction)
        {
            TransactionCollection.InsertOneAsync(transaction);
            return transaction;
        }
                

        public void DeleteTransaction(string id)
        {
            TransactionCollection.DeleteOneAsync(x => x.Id == id);
        }

        public FileStream ExportTransactions()
        {
            var transactions = GetTransactions();

            throw new NotImplementedException();
        }

        public IList<Transaction> GetTransactions()
        {
            var filter = new BsonDocument();
            var transactions = TransactionCollection.Find(filter).ToListAsync().Result;
            return transactions;
        }

        public double TotalAmount(string accountId, CryptoCurrencyType currencyType = CryptoCurrencyType.BitCoin)
        {
            var balance = TransactionCollection.Aggregate()
                .Match(x => x.AccountId == accountId && currencyType == x.CurrencyType)
                .Group(x => x.AccountId, y => new { Account = y.Key, Balance = y.Sum(z => z.Amount) })
                .FirstOrDefaultAsync().Result;

            if (balance == null) return 0;
            return balance.Balance;
        }

        public void UpdateTransaction(string id, Transaction transaction)
        {
            var existingTransaction = GetTransactionById(id);
            if(existingTransaction== null)
            {
                throw new ArgumentException("Transaction does not exist.");
            }
            throw new NotImplementedException();
        }

        public Transaction GetTransactionById(string id)
        {
            var transaction = TransactionCollection.Find(x => x.Id == id).FirstOrDefaultAsync().Result;
            return transaction;
        }

        public void CreateTransaction(Transaction transaction)
        {
            TransactionCollection.InsertOneAsync(transaction);
        }
    }
}
