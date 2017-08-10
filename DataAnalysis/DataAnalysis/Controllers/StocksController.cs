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
        public JsonResult GetResult(String symbol, int date, int start, int end)
        {
            IList<Stock> result = sh.GetStocksByFourParams(symbol, date, start, end);
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
