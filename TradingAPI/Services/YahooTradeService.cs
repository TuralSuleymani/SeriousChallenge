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

            for(int i = 1;i < tradeOpenValues.Count;i++)
            {
                CompareResult(tradeOpenValues[0], tradeOpenValues[i]);
            }
            var comparisonTradeOpenValues = marketDataResponse.Chart.Result[0].Comparisons[0].Open;
            return new ComparisonResponse();
        }

        private decimal CompareResult(decimal initial, decimal secondary)
        {
            return (secondary / initial) * 100;
        }
    }
}
