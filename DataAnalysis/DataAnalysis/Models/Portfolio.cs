using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAnalysis.Models
{
    public class Portfolio
    {
        public string Symbol { get; set; }
        public double High { get; set; }
        public double Low { get; set; }

        public double HighOpen { get; set; }
        public double LowOpen { get; set; }

        public double HighClose { get; set; }
        public double LowClose{ get; set; }

    }
}