using JwtAuthDemo.Helpers;
using JwtAuthDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    public class EducationalBackgroundController : Controller
    {
        private readonly EducationalBackgroundHelper _context;
        private readonly Appdatacontext _appdatacontext;

        public EducationalBackgroundController(Appdatacontext context)
        {
            _context = new EducationalBackgroundHelper(context);
            _appdatacontext = context;
        }



        // GET: EducationalInformationsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EducationalInformationsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EducationalInformationsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EducationalInformationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EducationalInformationsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EducationalInformationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EducationalInformationsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EducationalInformationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
