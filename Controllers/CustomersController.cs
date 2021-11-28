using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using PagedList;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        private RentACarDBContext db = new RentACarDBContext();

        // GET: Customers
        public ActionResult Index(string searchWord, string sortOrder, string currentFilter, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.FnameSortParm = String.IsNullOrEmpty(sortOrder) ? "Fname" : " ";
            ViewBag.LnameParm = String.IsNullOrEmpty(sortOrder) ? "Lname" : " ";


            if (searchWord != null)
            {
                page = 1;
            }
            else
            {
                searchWord = currentFilter;
            }
            ViewBag.CurrentFilter = searchWord;



            




            var customers = from s in db.Customers
                         select s;
            if (!String.IsNullOrEmpty(searchWord))
            {
                customers = customers.Where(s => s.Fname.Contains(searchWord)
                                       || s.Lname.Contains(searchWord));
            }


            switch (sortOrder)
            {
                case "Fname":
                    customers = customers.OrderByDescending(s => s.Fname);
                    break;
                case "Lname":
                    customers = customers.OrderByDescending(s => s.Lname);
                    break;
                default:
                    customers = customers.OrderBy(s => s.Fname);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(customers.ToPagedList(pageNumber, pageSize));

        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fname,Lname,age,City,PostCode,PhoneNumber")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customers);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fname,Lname,age,City,PostCode,PhoneNumber")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customers);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customers = db.Customers.Find(id);
            db.Customers.Remove(customers);
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
