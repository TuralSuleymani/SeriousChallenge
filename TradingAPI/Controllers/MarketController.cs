using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using TradingAPI.Models;
using TradingAPI.Services;

namespace TradingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarketController : ControllerBase
    {
        private readonly ILogger<MarketController> _logger;
        private readonly ITradeService _tradeService;

        public MarketController(ITradeService tradeService, ILogger<MarketController> logger)
        {
            _tradeService = tradeService;
            _logger = logger;
        }

        [HttpGet("compare")]
        public ComparisonResponse GetComparisonResult(string symbol,string comparison)
        {
           var comparisonResponse = _tradeService.CalculateComparison(symbol, comparison);
            return comparisonResponse;
        }
    }
}
