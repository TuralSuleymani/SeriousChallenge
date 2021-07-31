using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using TradingAPI.Models;

namespace TradingAPI.Services
{
    public class YahooTradeService : ITradeService
    {
        private readonly YahooFinanceService _financeService;
        public YahooTradeService(YahooFinanceService financeService)
        {
            _financeService = financeService;
        }
        public ComparisonResponse CalculateComparison(string symbol, string comparison)
        {
            string apiResponse =  _financeService.GetResponseString(symbol, comparison);
            var rsp = new ComparisonResponse();
            var marketDataResponse = JsonConvert.DeserializeObject<MarketDataResponse>(apiResponse);
            var tradetimestamps = marketDataResponse.Chart.Result[0].Timestamp;
            var tradeOpenValues = marketDataResponse.Chart.Result[0].Indicators.Quote[0].Open;
            var comparisonTradeOpenValues = marketDataResponse.Chart.Result[0].Comparisons[0].Open;

            rsp.ComparisonItems.Add(new ComparisonItem
            {
                TimeStamp = tradetimestamps[0],
                 Date = UnixTimeStampToDateTime(tradetimestamps[0]),
                 Source = new Container
                 {
                     Symbol = marketDataResponse.Chart.Result[0].Meta.Symbol,
                    Performance = CompareResult(tradeOpenValues[0], tradeOpenValues[0]),
                 },
                 Opposite = new Container
                 {
                      Symbol = marketDataResponse.Chart.Result[0].Comparisons[0].symbol,
                       Performance = CompareResult(comparisonTradeOpenValues[0], comparisonTradeOpenValues[0])
                 }
            });

            for(int i = 1;i < tradeOpenValues.Count;i++)
            {
                rsp.ComparisonItems.Add(new ComparisonItem
                {
                    TimeStamp = tradetimestamps[1],
                    Date = UnixTimeStampToDateTime(tradetimestamps[0]),
                    Source = new Container
                    {
                        Symbol = marketDataResponse.Chart.Result[0].Meta.Symbol,
                        Performance = CompareResult(tradeOpenValues[0], tradeOpenValues[i])
                    },
                    Opposite = new Container
                    {
                        Symbol = marketDataResponse.Chart.Result[0].Comparisons[0].symbol,
                        Performance = CompareResult(comparisonTradeOpenValues[0], comparisonTradeOpenValues[i])
                    }
                });
            }

            return rsp;
        }

        private string CompareResult(decimal initial, decimal secondary)
        {
            return (secondary / initial).ToString("P");
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
