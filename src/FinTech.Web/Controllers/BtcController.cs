using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FinTech.Core.Models;
using FinTech.Core.Interfaces;
using MongoDB.Bson;
using FinTech.Core.Services;
using FinTech.Web.Helpers;

namespace FinTech.Web.Controllers
{
    [Route("api/btc")]
    public class BtcController : Controller
    {
        public BtcService BtcService { get; set; }
        public BtcController(BtcService btcService)
        {
            BtcService = btcService;
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var transaction = BtcService.LookupTransactionInfo(id);
            return new JsonResult(new { transaction }, JsonHelper.GetConfiguredOutputFormatter().SerializerSettings);
        }
        
    }
}
