using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Schoolmc1.Models;

namespace Schoolmc1.Controllers
{
    public class CoursesController : Controller
    {
        private SchoolDataEntities1 db = new SchoolDataEntities1();
      
        // GET: Courses
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return View("Index", db.Courses.ToList());
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseTitle,CourseTime,CourseDay,CourseFee,Level,Professor,CoreCourse")] Course course)
        {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseTitle,CourseTime,CourseDay,CourseFee,Level,Professor,CoreCourse")] Course course)
        {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
