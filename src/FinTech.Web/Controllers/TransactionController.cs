using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FinTech.Core.Models;
using FinTech.Core.Interfaces;
using MongoDB.Bson;

namespace FinTech.Web.Controllers
{
    [Route("api/transactions")]
    public class TransactionController : Controller
    {
        public ITransactionService TransactionService { get; set; }
        public TransactionController(ITransactionService transactionService)
        {
            TransactionService = transactionService;
        }

        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return TransactionService.GetTransactions();
        }
        
        [HttpGet("{id}")]
        public Transaction Get(string id)
        {
            return TransactionService.GetTransactionById(id);
        }
        
        [HttpPost]
        public void Create([FromBody]Transaction transaction)
        {
            TransactionService.CreateTransaction(transaction);
        }
        
        [HttpPut("{id}")]
        public void Update(string id, [FromBody]Transaction transaction)
        {
            TransactionService.UpdateTransaction(id, transaction);
        }
        
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            TransactionService.DeleteTransaction(id);
        }

        [HttpPost("export")]
        public void Export()
        {
            var exported = TransactionService.ExportTransactions();
        }

    }
}
