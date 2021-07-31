using TradingAPI.Models;

namespace TradingAPI.Services
{
    public interface ITradeService
    {
        ComparisonResponse CalculateComparison(string apiResponse);
    }
}