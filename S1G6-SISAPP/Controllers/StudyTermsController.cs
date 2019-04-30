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
    public class StudyTermsController : Controller
    {
        private Entities db = new Entities();

        // GET: StudyTerms
        public ActionResult Index(String SearchString, String sortBy)
        {
            ViewBag.SortName = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            var StudyTerms = from st in db.StudyTerms select st;

            StudyTerms = StudyTerms.Where(st => st.TermName.Contains(SearchString)
            || SearchString == null);

            switch (sortBy)
            {
                case "Name desc":
                    StudyTerms = StudyTerms.OrderByDescending(st => st.TermName);
                    break;
                default:
                    StudyTerms = StudyTerms.OrderBy(st => st.TermName);
                    break;
            }
            return View(StudyTerms.ToList());
        }

        // GET: StudyTerms/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyTerm studyTerm = db.StudyTerms.Find(id);
            if (studyTerm == null)
            {
                return HttpNotFound();
            }
            return View(studyTerm);
        }

        // GET: StudyTerms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudyTerms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TermID,TermName,TermStartDate,TermEndDate,TermYear,TermSeason")] StudyTerm studyTerm)
        {
            if (ModelState.IsValid)
            {
                db.StudyTerms.Add(studyTerm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studyTerm);
        }

        // GET: StudyTerms/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyTerm studyTerm = db.StudyTerms.Find(id);
            if (studyTerm == null)
            {
                return HttpNotFound();
            }
            return View(studyTerm);
        }

        // POST: StudyTerms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TermID,TermName,TermStartDate,TermEndDate,TermYear,TermSeason")] StudyTerm studyTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studyTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studyTerm);
        }

        // GET: StudyTerms/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyTerm studyTerm = db.StudyTerms.Find(id);
            if (studyTerm == null)
            {
                return HttpNotFound();
            }
            return View(studyTerm);
        }

        // POST: StudyTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudyTerm studyTerm = db.StudyTerms.Find(id);
            db.StudyTerms.Remove(studyTerm);
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
