using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAnalysis.Models;

namespace DataAnalysis.Test
{
    [TestClass]
    public class StockTest
    {
        Stock s = null; 

        [TestInitialize]
        public void Setup()
        {
            s = new Stock();
        }

        [TestMethod]
        public void TestStockExists()
        {
            Assert.IsNotNull(s);
        }
    }
}
