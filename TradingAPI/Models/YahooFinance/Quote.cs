using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingAPI.Models
{
    public class Quote
    {
        public List<decimal> Close { get; set; }
        public List<decimal> Open { get; set; }
        public List<decimal> High { get; set; }
        public List<decimal> Low { get; set; }
        public List<int> Volume { get; set; }
    }
}
