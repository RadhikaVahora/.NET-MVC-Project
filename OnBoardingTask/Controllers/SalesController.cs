using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnBoardingTask.Models;

namespace OnBoardingTask.Controllers
{
    public class SalesController : Controller
    {
        private DataEntities db = new DataEntities();

        // GET: Sales
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Customer).Include(s => s.Product).Include(s => s.Store);
            return View(sales.ToList());
        }
        
        // GET: Sales/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            ViewBag.StoreId = new SelectList(db.Store, "StoreId", "StoreName");
            ViewBag.ProductId = new SelectList(db.Product, "ProductId", "ProductName");

            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesId,CustomerId,StoreId,ProductId,Date")] Sales sales)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", sales.CustomerId);
            ViewBag.StoreId = new SelectList(db.Store, "StoreId", "StoreName", sales.StoreId);
            ViewBag.ProductId = new SelectList(db.Product, "ProductId","ProductName",sales.ProductId);
            return View(sales);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", sales.CustomerId);
            ViewBag.StoreId = new SelectList(db.Store, "StoreId", "StoreName", sales.StoreId);
            return View(sales);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesId,CustomerId,StoreId")] Sales sales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", sales.CustomerId);
            ViewBag.StoreId = new SelectList(db.Store, "StoreId", "StoreName", sales.StoreId);
            return View(sales);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return View(sales);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sales sales = db.Sales.Find(id);
            db.Sales.Remove(sales);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
