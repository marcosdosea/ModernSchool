using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Controllers
{
    public class PeriodoController : Controller
    {
        private readonly IPeriodoService _periodoService;
        private readonly IMapper _mapper;

        public PeriodoController(IPeriodoService periodoService, IMapper mapper)
        {
            _periodoService = periodoService;
            _mapper = mapper;
        }

        // GET: PeriodoController
        public ActionResult Index()
        {
            var listaPeriodos = _periodoService.GetAll();
            var listaPeriodosModel = _mapper.Map<List<PeriodoViewModel>>(listaPeriodos);
            return View(listaPeriodosModel);
        }

        // GET: PeriodoController/Details/5
        public ActionResult Details(int id)
        {
            Periodo periodo = _periodoService.Get(id);
            PeriodoViewModel periodoModel = _mapper.Map<PeriodoViewModel>(periodo);
            return View(periodoModel);
        }

        // GET: PeriodoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeriodoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PeriodoViewModel periodoModel)
        {
            if (ModelState.IsValid)
            {
                var periodo = _mapper.Map<Periodo>(periodoModel);
                _periodoService.Create(periodo);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: PeriodoController/Edit/5
        public ActionResult Edit(int id)
        {
            Periodo periodo = _periodoService.Get(id);
            PeriodoViewModel periodoModel = _mapper.Map<PeriodoViewModel>(periodo);
            return View(periodoModel);
        }

        // POST: PeriodoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PeriodoViewModel periodoViewModel)
        {
            if (ModelState.IsValid)
            {
                var periodo = _mapper.Map<Periodo>(periodoViewModel);
                _periodoService.Edit(periodo);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PeriodoController/Delete/5
        public ActionResult Delete(int id)
        {
            Periodo periodo = _periodoService.Get(id);
            PeriodoViewModel periodoModel = _mapper.Map<PeriodoViewModel>(periodo);
            return View(periodoModel);
        }

        // POST: PeriodoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PeriodoViewModel periodoViewModel)
        {
            _periodoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
