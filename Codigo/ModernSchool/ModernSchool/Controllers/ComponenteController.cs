using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;
using ModernSchoolWEB.Models;
using Service;

namespace ModernSchoolWEB.Controllers
{
    public class ComponenteController : Controller
    {
        private readonly IComponenteService _componenteService;
        private readonly IMapper _mapper;

        public ComponenteController(IComponenteService componenteService, IMapper mapper)
        {
            _componenteService = componenteService;
            _mapper = mapper;
        }


        // GET: ComponenteController
        public ActionResult Index()
        {
            var listaComponente = _componenteService.GetAll();
            var listaComponenteModel = _mapper.Map<List<ComponenteViewModel>>(listaComponente);
            return View(listaComponenteModel);
        }

        // GET: ComponenteController/Details/5
        public ActionResult Details(int id)
        {
            Componente componente = _componenteService.Get(id);
            ComponenteViewModel componenteModel = _mapper.Map<ComponenteViewModel>(componente);
            return View(componenteModel);
        }

        // GET: ComponenteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComponenteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComponenteViewModel componenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var componente = _mapper.Map<Componente>(componenteViewModel);
                _componenteService.Create(componente);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ComponenteController/Edit/5
        public ActionResult Edit(int id)
        {
            Componente componente = _componenteService.Get(id);
            ComponenteViewModel componenteModel = _mapper.Map<ComponenteViewModel>(componente);
            return View(componenteModel);
        }

        // POST: ComponenteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ComponenteViewModel componenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var componente = _mapper.Map<Componente>(componenteViewModel);
                _componenteService.Edit(componente);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ComponenteController/Delete/5
        public ActionResult Delete(int id)
        {
            Componente componente = _componenteService.Get(id);
            ComponenteViewModel componenteViewModel = _mapper.Map<ComponenteViewModel>(componente);
            return View(componenteViewModel);
        }

        // POST: ComponenteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ComponenteViewModel componenteViewModel)
        {
            _componenteService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
