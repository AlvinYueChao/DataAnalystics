using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAnalysis.Controllers;
using System.Web.Mvc;

namespace DataAnalysis.Test
{
    /// <summary>
    /// HomeControllerTest 的摘要说明
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        HomeController hc = null;

        [TestInitialize]
        public void Setup()
        {
            hc = new HomeController();
        }

        [TestMethod]
        public void TestHomeControllerExists()
        {
            Assert.IsNotNull(hc);
        }

        [TestMethod]
        public void TestCanGetIndex()
        {
            var result = hc.Index() as ViewResult;
            Assert.AreEqual("" ,result.ViewName);
        }

        [TestMethod]
        public void TestCanGetAbout()
        {
            var result = hc.About() as ViewResult;
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void TestCanGetContact()
        {
            var result = hc.Contact() as ViewResult;
            Assert.AreEqual("", result.ViewName);
        }

    }
}
