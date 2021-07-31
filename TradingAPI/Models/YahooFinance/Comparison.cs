using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingAPI.Models
{
    public class Comparison
    {
        public string symbol { get; set; }
        public List<decimal> High { get; set; }
        public List<decimal> Low { get; set; }
        public decimal ChartPreviousClose { get; set; }
        public List<decimal> Close { get; set; }
        public List<decimal> Open { get; set; }
    }
}
