using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingAPI.Models
{
    public class Chart
    {
        public List<Result> Result { get; set; }
        public object Error { get; set; }
    }
}
