using AutoMapper;
using Core.Service;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Controllers
{
    public class DiarioDeClasseController : Controller
    {
        private readonly IDiarioDeClasseService _diarioDeClasseService;
        private readonly IMapper _mapper;
        public DiarioDeClasseController(IDiarioDeClasseService diarioDeClasseService, IMapper mapper)
        {
            _diarioDeClasseService = diarioDeClasseService;
            _mapper = mapper;
        }
        // GET: DiarioDeClasseController
        public ActionResult Index()
        {
            var listaDiarioDeClasse = _diarioDeClasseService.GetAll();
            var listaDiarioDeClasseModel = _mapper.Map<List<DiarioDeClasseViewModel>>(listaDiarioDeClasse);
            return View(listaDiarioDeClasseModel);
        }

        // GET: DiarioDeClasseController/Details/5
        public ActionResult Details(int id)
        {
            Diariodeclasse diariodeclasse = _diarioDeClasseService.Get(id);
            DiarioDeClasseViewModel diarioDeClasseModel = _mapper.Map<DiarioDeClasseViewModel>(diariodeclasse);
            return View(diarioDeClasseModel);

        }

        // GET: DiarioDeClassController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiarioDeClassController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DiarioDeClasseViewModel diarioDeClasseViewModel)
        {
            if (ModelState.IsValid)
            {
                var diarioDeClasse = _mapper.Map<Diariodeclasse>(diarioDeClasseViewModel);
                _diarioDeClasseService.Create(diarioDeClasse);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DiarioDeClassController/Edit/5
        public ActionResult Edit(int id)
        {
            Diariodeclasse diariodeclasse = _diarioDeClasseService.Get(id);
            DiarioDeClasseViewModel diarioDeClasseModel = _mapper.Map<DiarioDeClasseViewModel>(diariodeclasse);
            return View(diarioDeClasseModel);
        }

        // POST: DiarioDeClassController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DiarioDeClasseViewModel diarioDeClasseViewModel)
        {
            if (ModelState.IsValid)
            {
                var diariodeclasse = _mapper.Map<Diariodeclasse>(diarioDeClasseViewModel);
                _diarioDeClasseService.Edit(diariodeclasse);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DiarioDeClassController/Delete/5
        public ActionResult Delete(int id)
        {
            Diariodeclasse diariodeclasse = _diarioDeClasseService.Get(id);
            DiarioDeClasseViewModel diarioDeClasseModel = _mapper.Map<DiarioDeClasseViewModel>(diariodeclasse);
            return View(diarioDeClasseModel);
        }

        // POST: DiarioDeClasseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DiarioDeClasseViewModel diarioDeClasseViewModel)
        {
            _diarioDeClasseService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
