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
    public class CarsController : Controller
    {
        private RentACarDBContext db = new RentACarDBContext();

        // GET: Cars
        public ActionResult Index(string searchWord,string sortOrder,string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.BrandSortParm = String.IsNullOrEmpty(sortOrder) ? "brand" : " ";
            ViewBag.ModelParm = String.IsNullOrEmpty(sortOrder) ? "model" : " ";


            if (searchWord != null)
            {
                page = 1;
            }
            else
            {
                searchWord = currentFilter;
            }
            ViewBag.CurrentFilter = searchWord;



            var cars = from s in db.Cars
                       select s;
            if (!String.IsNullOrEmpty(searchWord))
            {
                cars = cars.Where(s => s.Brand.Contains(searchWord)
                                       || s.Model.Contains(searchWord));
            }

            switch (sortOrder)
            {
                case "brand":
                    cars = cars.OrderByDescending(s => s.Brand);
                    break;
                case "model":
                    cars = cars.OrderByDescending(s => s.Model);
                    break;
                default:
                    cars = cars.OrderBy(s => s.Brand );
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(cars.ToPagedList(pageNumber,pageSize));
    
            
        }


        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Brand,Model,EngineType,HorsePower,IsAutomatic,YearOfManufacture,SortableId")] Cars cars)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(cars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cars);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Brand,Model,EngineType,HorsePower,IsAutomatic,YearOfManufacture,SortableId")] Cars cars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cars);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars cars = db.Cars.Find(id);
            db.Cars.Remove(cars);
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
