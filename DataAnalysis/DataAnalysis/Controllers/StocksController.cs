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

        // GET: Stocks
        public ActionResult Index(String symbol, int date, int start, int end)
        {
            //IList<Stock> allstocks = db.Stocks.ToList();
            //var result = (from s in allstocks
            //              where s.Symbol == symbol && s.Date == date
            //              select s).ToList();
            //return View(result);
            IList<Stock> result = sh.GetStocksByFourParams(symbol, date, start, end);
            return View(result);
        }

        // GET: Stocks
        [HttpGet]
        public JsonResult GetResult(String symbol, int date, int start, int end)
        {
            IList<Stock> result = sh.GetStocksByFourParams(symbol, date, start, end);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //// GET: Stocks/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Stock stock = db.Stocks.Find(id);
        //    if (stock == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(stock);
        //}

        //// GET: Stocks/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Stocks/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Symbol,Date,Time,Open,High,Low,Close,Volume,SplitFactor")] Stock stock)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Stocks.Add(stock);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(stock);
        //}

        //// GET: Stocks/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Stock stock = db.Stocks.Find(id);
        //    if (stock == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(stock);
        //}

        //// POST: Stocks/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Symbol,Date,Time,Open,High,Low,Close,Volume,SplitFactor")] Stock stock)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(stock).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(stock);
        //}

        //// GET: Stocks/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Stock stock = db.Stocks.Find(id);
        //    if (stock == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(stock);
        //}

        //// POST: Stocks/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Stock stock = db.Stocks.Find(id);
        //    db.Stocks.Remove(stock);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
