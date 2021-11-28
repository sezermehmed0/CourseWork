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
    public class RentalsController : Controller
    {
        private RentACarDBContext db = new RentACarDBContext();

        // GET: Rentals
        public ActionResult Index(string searchWord, string sortOrder, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.BrandSortParm = String.IsNullOrEmpty(sortOrder) ? "Brand" : " ";
            ViewBag.ModelParm = String.IsNullOrEmpty(sortOrder) ? "Model" : " ";



            if (searchWord != null)
            {
                page = 1;
            }
            else
            {
                searchWord = currentFilter;
            }
            ViewBag.CurrentFilter = searchWord;




            var Rental = from s in db.Rental
                       select s;
            if (!String.IsNullOrEmpty(searchWord))
            {
                Rental = Rental.Where(s => s.Brand.Contains(searchWord)
                                       || s.Model.Contains(searchWord));
            }
            switch (sortOrder)
            {
                case "Brand":
                    Rental = Rental.OrderByDescending(s => s.Brand);
                    break;
                case "Model":
                    Rental = Rental.OrderByDescending(s => s.Model);
                    break;
                default:
                    Rental = Rental.OrderBy(s => s.Brand);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(Rental.ToPagedList(pageNumber, pageSize));
          

        }

        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rental.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CarId,CustomerId,Brand,Model,DailyPrice,IsAutomatic,IsAvailable,RentedFromThisDate,RentedToThisDate")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Rental.Add(rental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rental);
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rental.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CarId,CustomerId,Brand,Model,DailyPrice,IsAutomatic,IsAvailable,RentedFromThisDate,RentedToThisDate")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rental.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rental rental = db.Rental.Find(id);
            db.Rental.Remove(rental);
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
