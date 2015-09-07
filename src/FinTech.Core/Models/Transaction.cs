using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Core.Models
{
    public class Transaction
    {
        [BsonId]
        public string Id { get; set; }
        public string AccountId { get; set; }
        public DateTime Timestamp { get; set; }
        public double Amount { get; set; }
        public CryptoCurrencyType CurrencyType { get; set; } = CryptoCurrencyType.BitCoin;
        public string BlockChain { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }


    }

    public enum CryptoCurrencyType
    {
        BitCoin = 1,
        LiteCoin = 2,
        DodgeCoin = 3
    }
}
