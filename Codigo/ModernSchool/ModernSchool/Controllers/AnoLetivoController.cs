using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModernSchool.Controllers
{
    public class AnoLetivoController : Controller
    {
        // GET: AnoLetivoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AnoLetivoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AnoLetivoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnoLetivoController/Create
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

        // GET: AnoLetivoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnoLetivoController/Edit/5
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

        // GET: AnoLetivoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnoLetivoController/Delete/5
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
