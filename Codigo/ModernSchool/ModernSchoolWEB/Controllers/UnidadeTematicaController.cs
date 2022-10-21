using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Controllers
{
    public class UnidadeTematicaController : Controller
    {
        private readonly IUnidadeTematicaService _unidadeTematicaService;
        private readonly IMapper _mapper;

        public UnidadeTematicaController(IUnidadeTematicaService unidadeTematicaService, IMapper mapper)
        {
            _unidadeTematicaService = unidadeTematicaService;
            _mapper = mapper;
        }

        // GET: UnidadeTematicaController
        public ActionResult Index()
        {
            var listaUnidadeTematica = _unidadeTematicaService.GetAll();
            var listaUnidadeTematicaModel = _mapper.Map<List<UnidadeTematicaViewModel>>(listaUnidadeTematica);
            return View(listaUnidadeTematicaModel);
        }

        // GET: UnidadeTematicaController/Details/5
        public ActionResult Details(int id)
        {
            Unidadetematica unidadeTematica = _unidadeTematicaService.Get(id);
            UnidadeTematicaViewModel unidadeTematicaModel = _mapper.Map<UnidadeTematicaViewModel>(unidadeTematica);
            return View(unidadeTematicaModel);
        }

        // GET: UnidadeTematicaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnidadeTematicaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UnidadeTematicaViewModel unidadeTematicaViewModel)
        {
            if (ModelState.IsValid)
            {
                var unidadeTematica = _mapper.Map<Unidadetematica>(unidadeTematicaViewModel);
                _unidadeTematicaService.Create(unidadeTematica);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: UnidadeTematicaController/Edit/5
        public ActionResult Edit(int id)
        {
            Unidadetematica unidadeTematica = _unidadeTematicaService.Get(id);
            UnidadeTematicaViewModel unidadeTematicaModel = _mapper.Map<UnidadeTematicaViewModel>(unidadeTematica);
            return View(unidadeTematicaModel);
        }

        // POST: UnidadeTematicaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UnidadeTematicaViewModel unidadeTematicaViewModel)
        {
            if (ModelState.IsValid)
            {
                var unidadeTematica = _mapper.Map<Unidadetematica>(unidadeTematicaViewModel);
                _unidadeTematicaService.Edit(unidadeTematica);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: UnidadeTematicaController/Delete/5
        public ActionResult Delete(int id)
        {
            Unidadetematica unidadeTematica = _unidadeTematicaService.Get(id);
            UnidadeTematicaViewModel unidadeTematicaViewModel = _mapper.Map<UnidadeTematicaViewModel>(unidadeTematica);
            return View(unidadeTematicaViewModel);
        }

        // POST: UnidadeTematicaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UnidadeTematicaViewModel unidadeTematicaViewModel)
        {
            _unidadeTematicaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
