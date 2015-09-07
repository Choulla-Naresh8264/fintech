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
    public class BtcService: IBtcService
    {
        private ICoinService CoinService { get; set; } 
        public IConfiguration Configuration { get; set; }

        public BtcService(IConfiguration configuration)
        {
            Configuration = configuration;

            var url = Configuration.GetSection("Settings:Bitcoin_DaemonUrl").Value;
            var username = Configuration.GetSection("Settings:Bitcoin_RpcUsername").Value;
            var password = Configuration.GetSection("Settings:Bitcoin_RpcPassword").Value;

            CoinService = new BitcoinService(url, username, password);

        }

        public void GetInfo(string id)
        {
            var networkDifficulty = CoinService.GetDifficulty();
            var myBalance = CoinService.GetBalance();
            var transaction = CoinService.GetTransaction(id);
        }
    }
}
