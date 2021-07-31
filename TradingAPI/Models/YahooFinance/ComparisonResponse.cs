using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingAPI.Models
{
    public class ComparisonResponse
    {
        public List<ComparisonItem> ComparisonItems { get; set; }
        public ComparisonResponse()
        {
            ComparisonItems = new List<ComparisonItem>();
        }
    }
}
