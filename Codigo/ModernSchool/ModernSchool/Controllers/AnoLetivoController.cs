using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchool.Models;
using ModernSchoolWEB.Models;
using Service;

namespace ModernSchool.Controllers
{
    public class AnoLetivoController : Controller
    {
        private readonly IAnoLetivoService _anoLetivoService;
        private readonly IMapper _mapper;
        public AnoLetivoController(IAnoLetivoService anoLetivoService, IMapper mapper)
        {
            _anoLetivoService = anoLetivoService;
            _mapper = mapper;
        }
        // GET: AnoLetivoController
        public ActionResult Index()
        {
            var listaAnoLetivos = _anoLetivoService.GetAll();
            var listaAnoLetivosModel = _mapper.Map<List<AnoLetivoViewModel>>(listaAnoLetivos);
            return View(listaAnoLetivosModel);
        }

        // GET: AnoLetivoController/Details/5
        public ActionResult Details(int id)
        {
            Anoletivo anoLetivo = _anoLetivoService.Get(id);
            AnoLetivoViewModel AnoLetivoModel = _mapper.Map<AnoLetivoViewModel>(anoLetivo);
            return View(AnoLetivoModel);
        }

        // GET: AnoLetivoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnoLetivoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnoLetivoViewModel anoLetivoModel)
        {
            if (ModelState.IsValid)
            {
                var anoLetivo = _mapper.Map<Anoletivo>(anoLetivoModel);
                _anoLetivoService.Create(anoLetivo);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AnoLetivoController/Edit/5
        public ActionResult Edit(int id)
        {
            Anoletivo anoLetivo = _anoLetivoService.Get(id);
            AnoLetivoViewModel anoLetivoModel = _mapper.Map<AnoLetivoViewModel>(anoLetivo);
            return View(anoLetivoModel);
        }

        // POST: AnoLetivoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AnoLetivoViewModel anoLetivoModel)
        {
            if (ModelState.IsValid)
            {
                var anoLetivo = _mapper.Map<Anoletivo>(anoLetivoModel);
                _anoLetivoService.Edit(anoLetivo);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AnoLetivoController/Delete/5
        public ActionResult Delete(int id)
        {
            Anoletivo anoLetivo = _anoLetivoService.Get(id);
            AnoLetivoViewModel anoLetivoModel = _mapper.Map<AnoLetivoViewModel>(anoLetivo);
            return View(anoLetivoModel);
        }

        // POST: AnoLetivoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AnoLetivoViewModel anoLetivoModel)
        {
            _anoLetivoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
