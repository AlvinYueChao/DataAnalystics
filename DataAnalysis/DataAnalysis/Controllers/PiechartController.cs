using DataAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAnalysis.Controllers
{
    public class PiechartController : Controller
    {
        private IList<Stock> result = new List<Stock>();
        private StockHandler sh = new StockHandler();
        // GET: Piechart
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetCharts(String dateTime)
        {
            result = sh.GetStocksByDateTime(dateTime).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}