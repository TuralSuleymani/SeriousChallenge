using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private const string ROOT_SEGMENT = "market";
        private readonly ILogger<MarketController> _logger;
        private readonly ITradeService _tradeService;

        public MarketController(ITradeService tradeService,ILogger<MarketController> logger)
        {
            _tradeService = tradeService;
            _logger = logger;
        }

        [HttpGet("compare")]
        public ComparisonResponse GetComparisonResult(string symbol,string comparison)
        {
            symbol ??= "MSFT";
            comparison ??= "SPY";
            var rootAPI = "https://apidojo-yahoo-finance-v1.p.rapidapi.com";
            var subsegment = "get-charts";
            var queryString = $"symbol={symbol}&interval=1d&range=5d&region=US&comparisons={comparison}";
            var url = $"{rootAPI}/{ROOT_SEGMENT}/{subsegment}?{queryString}";


            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "ed5ad9ac08msh41b382f5138831ep15e870jsn647eedfd2402");
            request.AddHeader("x-rapidapi-host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            var response = client.Execute(request);
           var comparisonResponse = _tradeService.CalculateComparison(response.Content);
            return comparisonResponse;
        }
    }
}
