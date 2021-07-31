using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using TradingAPI.Models;

namespace TradingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarketController : ControllerBase
    {

        private readonly ILogger<MarketController> _logger;

        public MarketController(ILogger<MarketController> logger)
        {
            _logger = logger;
        }

        [HttpGet("compare")]
        public MarketDataResponse GetComparisonResult(string symbol,string comparison)
        {
            symbol = symbol ?? "MSFT";
            comparison = comparison ?? "SPY";
            var client = new RestClient($"https://apidojo-yahoo-finance-v1.p.rapidapi.com/market/get-charts?symbol={symbol}&interval=1d&range=5d&region=US&comparisons={comparison}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "ed5ad9ac08msh41b382f5138831ep15e870jsn647eedfd2402");
            request.AddHeader("x-rapidapi-host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            var response = client.Execute(request);
            var marketDataResponse = JsonConvert.DeserializeObject<MarketDataResponse>(response.Content);
            List<int> tradetimestamps = marketDataResponse.Chart.Result[0].Timestamp;
            var tradeOpenValues =  marketDataResponse.Chart.Result[0].Indicators.Quote[0].Open;
            var comparisonTradeOpenValues = marketDataResponse.Chart.Result[0].Comparisons[0].Open;
            return marketDataResponse;
        }
    }
}
