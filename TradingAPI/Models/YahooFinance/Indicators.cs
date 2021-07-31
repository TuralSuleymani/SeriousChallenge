using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingAPI.Models
{
    public class Indicators
    {
        public List<Quote> Quote { get; set; }
        public List<AdjClose> Adjclose { get; set; }
    }

}
