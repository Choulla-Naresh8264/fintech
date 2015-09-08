using FinTech.Core.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Core.Interfaces
{
    public interface IBtcService
    {
        Transaction LookupTransactionInfo(string id);
    }
}
