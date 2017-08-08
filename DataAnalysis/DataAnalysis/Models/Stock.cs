using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataAnalysis.Models
{
    public class Stock
    {
        public int ID { get; set; }
        public string Symbol { get; set; }
        public int Date { get; set; }
        public int Time { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
        public int SplitFactor { get; set; }
    }
}