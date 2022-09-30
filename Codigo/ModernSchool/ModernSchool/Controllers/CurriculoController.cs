using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchool.Models;
using Service;

namespace ModernSchool.Controllers
{
    public class CurriculoController : Controller
    {
        private readonly ICurriculoService _curriculoService;
        private readonly IMapper _mapper;

        public CurriculoController(ICurriculoService curriculoService, IMapper mapper)
        {
            _curriculoService = curriculoService;
            _mapper = mapper;
        }

        // GET: PeriodoController
        public ActionResult Index()
        {
            var listaCurriculo = _curriculoService.GetAll();
            var listaCurriculoModel = _mapper.Map<List<CurriculoViewModel>>(listaCurriculo);
            return View(listaCurriculoModel);
        }

        // GET: PeriodoController/Details/5
        public ActionResult Details(int id)
        {
            Curriculo curriculo = _curriculoService.Get(id);
            CurriculoViewModel curriculoModel = _mapper.Map<CurriculoViewModel>(curriculo);
            return View(curriculoModel);
        }

        // GET: PeriodoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeriodoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CurriculoViewModel curriculoModel)
        {
            if (ModelState.IsValid)
            {
                var curriculo = _mapper.Map<Curriculo>(curriculoModel);
                _curriculoService.Create(curriculo);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: PeriodoController/Edit/5
        public ActionResult Edit(int id)
        {
            Curriculo curriculo = _curriculoService.Get(id);
            CurriculoViewModel curriculoModel = _mapper.Map<CurriculoViewModel>(curriculo);
            return View(curriculoModel);
        }

        // POST: PeriodoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CurriculoViewModel curriculoViewModel)
        {
            if (ModelState.IsValid)
            {
                var curriculo = _mapper.Map<Curriculo>(curriculoViewModel);
                _curriculoService.Edit(curriculo);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PeriodoController/Delete/5
        public ActionResult Delete(int id)
        {
            Curriculo curriculo = _curriculoService.Get(id);
            CurriculoViewModel curriculoModel = _mapper.Map<CurriculoViewModel>(curriculo);
            return View(curriculoModel);
        }

        // POST: PeriodoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CurriculoViewModel curriculoViewModel)
        {
            _curriculoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
