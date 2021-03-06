﻿using FinTech.Core.Models;
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
        void ExportTransactions(string filename);

        double TotalAmount();
        void CreateTransaction(Transaction transaction);
    }
}
