using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingAPI.Models
{
    public class Comparison
    {
        public string symbol { get; set; }
        public List<double> High { get; set; }
        public List<double> Low { get; set; }
        public double ChartPreviousClose { get; set; }
        public List<double> Close { get; set; }
        public List<double> Open { get; set; }
    }
}
