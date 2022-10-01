using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ModernSchoolWEB.Models;
using Core;

namespace ModernSchoolWEB.Controllers
{
    public class GovernoController : Controller
    {
        private readonly IGovernoService _governoService;
        private readonly IMapper _mapper;

        public GovernoController (IGovernoService governoService, IMapper mapper)
        {
            _governoService = governoService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var listaGoverno = _governoService.GetAll();
            var listaGovernoModel = _mapper.Map<List<GovernoViewModel>>(listaGoverno);

            return View(listaGovernoModel);
        }

        // GET: GovernoController/Details/5
        public ActionResult Details(int id)
        {
            Governo listaGoverno = _governoService.Get(id);
            GovernoViewModel listaGoernoModel = _mapper.Map<GovernoViewModel>(listaGoverno);
            return View(listaGoernoModel);
        }

        // GET: GovernoController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: GovernoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GovernoViewModel governoViewModel)
        {
            if (ModelState.IsValid)
            {
                var _governo = _mapper.Map<Governo>(governoViewModel);
                _governoService.Crete(_governo);
            }
            
                return RedirectToAction(nameof(Index));
            
       
        }

        // GET: GovernoController/Edit/5
        public ActionResult Edit(int id)
        {
            Governo governo = _governoService.Get(id);
            _governoService.Edit(governo);
            return View();
        }

        // POST: GovernoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GovernoViewModel governoViewModel)
        {
                
            if (ModelState.IsValid)
            {
                var governo = _mapper.Map<Governo>(governoViewModel);
                _governoService.Edit(governo);
            }
                return RedirectToAction(nameof(Index));
   
        }

        // GET: GovernoController/Delete/5
        public ActionResult Delete(int id)
        {
            Governo governo = _governoService.Get(id);
            GovernoViewModel governoViewModel = _mapper.Map<GovernoViewModel>(governo);
            return View(governoViewModel);
        }

        // POST: GovernoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
                _governoService.Delete(id);
            
                return RedirectToAction(nameof(Index));

        }
    }
}
