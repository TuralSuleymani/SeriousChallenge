using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingAPI.Models
{
    public class Result
    {
        public Meta Meta { get; set; }
        public List<int> Timestamp { get; set; }
        public List<Comparison> Comparisons { get; set; }
        public Indicators Indicators { get; set; }
    }
}
