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
        private IList<Stock> result = new List<Stock>();
        private StockHandler sh = new StockHandler();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCharts(String symbol, int date)
        {
            result = sh.GetStocksByTwoParams(symbol, date).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Insert(String symbol)
        {
            bool result = sh.InsertSymbol(symbol);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}