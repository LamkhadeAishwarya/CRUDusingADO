using CRUDusingADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDusingADO.Controllers
{
    public class CourseController : Controller
    {
        // GET: CourseController
        CourseDAL db;
        IConfiguration configuration;
        public CourseController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new CourseDAL(configuration);
        }
        public ActionResult Index()
        {
            return View(db.GetCourse());
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            var cor= db.GetCourseById(id);
            return View(cor);
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course cor)
        {
            try
            {
                int result = db.AddCourse(cor);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var cor = db.GetCourseById(id);
            return View(cor);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course cor)
        {
            try
            {
                int result = db.UpdateCourse(cor);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            var cor= db.GetCourseById(id);
            return View(cor);
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = db.DeleteCourse(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
