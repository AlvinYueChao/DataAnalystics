using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAnalysis.Models;

namespace DataAnalysis.Controllers
{
    public class StocksController : Controller
    {
        private StockHandler sh = new StockHandler();
        private DetailHandler dh = new DetailHandler();

        // GET: Stocks
        public ActionResult Index()
        {
            return View();
        }

        // GET: Stocks
        [HttpGet]
        public JsonResult GetResult(String symbol, String startDateTime, String endDateTime)
        {
            IList<Stock> result = sh.GetStocksByThreeParams(symbol, startDateTime, endDateTime);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDetail(String symbol)
        {
            Detail detail = dh.GetDetailBySymbol(symbol);
            return Json(detail, JsonRequestBehavior.AllowGet);
        }
    }
}
