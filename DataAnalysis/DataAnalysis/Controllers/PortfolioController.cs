using DataAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAnalysis.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioHandler ph = new PortfolioHandler();
      //  IList<Portfolio> result = null;

        // GET: Portfolio
       
        public ActionResult Index(string id)
        {
            ViewBag.identity = id;
            return View();
        }

        [HttpGet]
        public JsonResult GetResult(String id, int startdate, int enddate)
        {
            IList<Portfolio> result = ph.GetPortfolioByFourParams(id, startdate, enddate);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}