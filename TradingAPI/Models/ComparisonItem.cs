using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingAPI.Models
{
    public class Container
    {
        public string Symbol { get; set; }
        public string Performance { get; set; }
    }
    public class ComparisonItem
    {
        public DateTime Date { get; set; }
        public int TimeStamp { get; set; }
        public Container Source { get; set; }
        public Container Opposite { get; set; }
    }
}
