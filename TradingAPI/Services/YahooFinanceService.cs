using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using RestSharp;
using TradingAPI.Models;

namespace TradingAPI.Services
{
    public class YahooFinanceService
    {
        private const string ROOT_SEGMENT = "market";
        private YahooConfig _tradeConfig;
        public YahooFinanceService( IOptions<YahooConfig> options)
        {
            _tradeConfig = options.Value;
        }

        public string GetResponseString([NotNull] string symbol, [NotNull] string comparison)
        {
            var rootAPI = _tradeConfig.Url;
            var subsegment = "get-charts";
            var queryString = $"symbol={symbol}&interval=1d&range=5d&region=US&comparisons={comparison}";
            var url = $"{rootAPI}/{ROOT_SEGMENT}/{subsegment}?{queryString}";
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", _tradeConfig.Rapidapikey);
            request.AddHeader("x-rapidapi-host", _tradeConfig.Rapidapihost);
            var response = client.Execute(request);
            return response.Content;
        }
    }
}
