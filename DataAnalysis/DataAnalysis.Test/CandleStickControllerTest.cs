using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAnalysis.Controllers;
using System.Web.Mvc;

namespace DataAnalysis.Test
{
    [TestClass]
    public class CandleStickControllerTest
    {
        CandlestickController cc = null;

        [TestInitialize]
        public void Setup()
        {
            cc = new CandlestickController();
        }
        
    }
}
