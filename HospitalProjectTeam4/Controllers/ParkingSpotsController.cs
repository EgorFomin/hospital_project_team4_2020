using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalProjectTeam4.Data;
using HospitalProjectTeam4.Models;

namespace HospitalProjectTeam4.Controllers
{
    public class ParkingSpotsController : Controller
    {
        private HospitalProjectContext db = new HospitalProjectContext();

        // GET: ParkingSpots
        public ActionResult Index()
        {
            var parkingSpots = db.ParkingSpots.Include(p => p.HospitalStaff);
            return View(parkingSpots.ToList());
        }

        // GET: ParkingSpots/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingSpot parkingSpot = db.ParkingSpots.Find(id);
            if (parkingSpot == null)
            {
                return HttpNotFound();
            }
            return View(parkingSpot);
        }

        // GET: ParkingSpots/Create
        public ActionResult Create()
        {
            ViewBag.StaffID = new SelectList(db.hospitalStaffs, "StaffID", "StaffFName");
            return View();
        }

        // POST: ParkingSpots/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParkingSpotID,StaffID,Name,Description")] ParkingSpot parkingSpot)
        {
            if (ModelState.IsValid)
            {
                db.ParkingSpots.Add(parkingSpot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StaffID = new SelectList(db.hospitalStaffs, "StaffID", "StaffFName", parkingSpot.StaffID);
            return View(parkingSpot);
        }

        // GET: ParkingSpots/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingSpot parkingSpot = db.ParkingSpots.Find(id);
            if (parkingSpot == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaffID = new SelectList(db.hospitalStaffs, "StaffID", "StaffFName", parkingSpot.StaffID);
            return View(parkingSpot);
        }

        // POST: ParkingSpots/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParkingSpotID,StaffID,Name,Description")] ParkingSpot parkingSpot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkingSpot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StaffID = new SelectList(db.hospitalStaffs, "StaffID", "StaffFName", parkingSpot.StaffID);
            return View(parkingSpot);
        }

        // GET: ParkingSpots/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingSpot parkingSpot = db.ParkingSpots.Find(id);
            if (parkingSpot == null)
            {
                return HttpNotFound();
            }
            return View(parkingSpot);
        }

        // POST: ParkingSpots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ParkingSpot parkingSpot = db.ParkingSpots.Find(id);
            db.ParkingSpots.Remove(parkingSpot);
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
