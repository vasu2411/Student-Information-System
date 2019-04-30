using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S1G6_SISAPP.Models;

namespace S1G6_SISAPP.Controllers
{
    public class Registration1Controller : Controller
    {
        private Entities db = new Entities();

        // GET: Registration1
        public ActionResult Index()
        {
            var registration1 = db.Registration1.Include(r => r.Cours).Include(r => r.Student).Include(r => r.StudyTerm);
            return View(registration1.ToList());
        }

        // GET: Registration1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration1 registration1 = db.Registration1.Find(id);
            if (registration1 == null)
            {
                return HttpNotFound();
            }
            return View(registration1);
        }

        // GET: Registration1/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentFirstName");
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName");
            return View();
        }

        // POST: Registration1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentID,CourseID,TermID")] Registration1 registration1)
        {
            if (ModelState.IsValid)
            {
                db.Registration1.Add(registration1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", registration1.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentFirstName", registration1.StudentID);
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName", registration1.TermID);
            return View(registration1);
        }

        // GET: Registration1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration1 registration1 = db.Registration1.Find(id);
            if (registration1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", registration1.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentFirstName", registration1.StudentID);
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName", registration1.TermID);
            return View(registration1);
        }

        // POST: Registration1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentID,CourseID,TermID")] Registration1 registration1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", registration1.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentFirstName", registration1.StudentID);
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName", registration1.TermID);
            return View(registration1);
        }

        // GET: Registration1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration1 registration1 = db.Registration1.Find(id);
            if (registration1 == null)
            {
                return HttpNotFound();
            }
            return View(registration1);
        }

        // POST: Registration1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration1 registration1 = db.Registration1.Find(id);
            db.Registration1.Remove(registration1);
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
