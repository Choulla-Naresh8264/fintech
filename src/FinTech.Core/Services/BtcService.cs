using BitcoinLib.Services.Coins.Base;
using BitcoinLib.Services.Coins.Bitcoin;
using FinTech.Core.Interfaces;
using Microsoft.Framework.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Core.Services
{
    public class BtcService : IBtcService
    {
        public IConfiguration Configuration { get; set; }

        public BtcService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void GetInfo(string id)
        {
            throw new NotImplementedException();
        }
    }
}
