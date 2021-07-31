using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingAPI.Models
{
    public class CurrentTradingPeriod
    {
        public Pre Pre { get; set; }
        public Regular Regular { get; set; }
        public Post Post { get; set; }
    }
}
