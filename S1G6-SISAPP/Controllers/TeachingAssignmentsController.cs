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
    public class TeachingAssignmentsController : Controller
    {
        private Entities db = new Entities();

        // GET: TeachingAssignments
        public ActionResult Index()
        {
            var teachingAssignment = db.TeachingAssignment.Include(t => t.Cours).Include(t => t.Instructor).Include(t => t.StudyTerm);
            return View(teachingAssignment.ToList());
        }

        // GET: TeachingAssignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeachingAssignment teachingAssignment = db.TeachingAssignment.Find(id);
            if (teachingAssignment == null)
            {
                return HttpNotFound();
            }
            return View(teachingAssignment);
        }

        // GET: TeachingAssignments/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorFirstName");
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName");
            return View();
        }

        // POST: TeachingAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InstructorID,CourseID,TermID")] TeachingAssignment teachingAssignment)
        {
            if (ModelState.IsValid)
            {
                db.TeachingAssignment.Add(teachingAssignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", teachingAssignment.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorFirstName", teachingAssignment.InstructorID);
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName", teachingAssignment.TermID);
            return View(teachingAssignment);
        }

        // GET: TeachingAssignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeachingAssignment teachingAssignment = db.TeachingAssignment.Find(id);
            if (teachingAssignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", teachingAssignment.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorFirstName", teachingAssignment.InstructorID);
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName", teachingAssignment.TermID);
            return View(teachingAssignment);
        }

        // POST: TeachingAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InstructorID,CourseID,TermID")] TeachingAssignment teachingAssignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teachingAssignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", teachingAssignment.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorFirstName", teachingAssignment.InstructorID);
            ViewBag.TermID = new SelectList(db.StudyTerms, "TermID", "TermName", teachingAssignment.TermID);
            return View(teachingAssignment);
        }

        // GET: TeachingAssignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeachingAssignment teachingAssignment = db.TeachingAssignment.Find(id);
            if (teachingAssignment == null)
            {
                return HttpNotFound();
            }
            return View(teachingAssignment);
        }

        // POST: TeachingAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeachingAssignment teachingAssignment = db.TeachingAssignment.Find(id);
            db.TeachingAssignment.Remove(teachingAssignment);
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
