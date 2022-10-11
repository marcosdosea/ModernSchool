using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModernSchoolWEB.Controllers
{
    public class EscolaController : Controller
    {
        private readonly IEscolaService _escolaService;
        private readonly IMapper _mapper;
        public EscolaController(IEscolaService escolaService, IMapper mapper)
        {
            _escolaService = escolaService;
            _mapper = mapper;
        }
        // GET: EscolaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EscolaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EscolaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EscolaController/Create
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

        // GET: EscolaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EscolaController/Edit/5
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

        // GET: EscolaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EscolaController/Delete/5
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
