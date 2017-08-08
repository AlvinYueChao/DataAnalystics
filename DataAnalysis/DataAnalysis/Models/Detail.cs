using System;

namespace DataAnalysis.Models
{
    public class Detail
    {
        public int ID { get; set; }
        public String EXP { get; set; }
        public String Symbol { get; set; }
        public String Name { get; set; }
        public double LastSale { get; set; }
        public String MarketCap { get; set; }
        public double IPOyear { get; set; }
        public String Sector { get; set; }
        public String Industry { get; set; }
        public String SummaryQuote { get; set; }
    }
}