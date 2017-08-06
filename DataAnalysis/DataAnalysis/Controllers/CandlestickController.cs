using DataAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DataAnalysis.Controllers
{
    public class CandlestickController : Controller
    {
        private List<Stock> result = new List<Stock>();
        private StockHandler sh = new StockHandler();
        // GET: Candlestck
        public ActionResult Index(String symbol, int date, int start, int end)
        {
            result = sh.GetStocksByParams(symbol, date, start, end).ToList();
            return View();
        }

        [HttpGet]
        public JsonResult GetCharts()
        {
            return Json(new { count = result.Count, data = result}, JsonRequestBehavior.AllowGet);
        }
    }
}