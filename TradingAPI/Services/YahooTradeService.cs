using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TradingAPI.Models;

namespace TradingAPI.Services
{
    public class YahooTradeService : ITradeService
    {
        public ComparisonResponse CalculateComparison(string apiResponse)
        {
            var marketDataResponse = JsonConvert.DeserializeObject<MarketDataResponse>(apiResponse);
            var tradetimestamps = marketDataResponse.Chart.Result[0].Timestamp;
            var tradeOpenValues = marketDataResponse.Chart.Result[0].Indicators.Quote[0].Open;
            var comparisonTradeOpenValues = marketDataResponse.Chart.Result[0].Comparisons[0].Open;
            return new ComparisonResponse();
        }
    }
}
