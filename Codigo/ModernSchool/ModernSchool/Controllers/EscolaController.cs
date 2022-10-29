using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;
using Service;

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
            var listaEscola = _escolaService.GetAll();
            var listaEscolaModel = _mapper.Map<List<EscolaViewModel>>(listaEscola);
            return View(listaEscolaModel);
        }

        // GET: EscolaController/Details/5
        public ActionResult Details(int id)
        {
            Escola escola = _escolaService.Get(id);
            EscolaViewModel escolaModel = _mapper.Map<EscolaViewModel>(escola);
            return View(escolaModel);
            
        }

        // GET: EscolaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EscolaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EscolaViewModel escolaViewModel)
        {
            if (ModelState.IsValid)
            {
                var escola = _mapper.Map<Escola>(escolaViewModel);
                _escolaService.Create(escola);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EscolaController/Edit/5
        public ActionResult Edit(int id)
        {
            Escola escola = _escolaService.Get(id);
            EscolaViewModel escolaModel = _mapper.Map<EscolaViewModel>(escola);
            return View(escolaModel);
        }

        // POST: EscolaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,EscolaViewModel escolaViewModel)
        {
            if (ModelState.IsValid)
            {
                var escola = _mapper.Map<Escola>(escolaViewModel);
                _escolaService.Edit(escola);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EscolaController/Delete/5
        public ActionResult Delete(int id)
        {
            Escola escola = _escolaService.Get(id);
            EscolaViewModel escolaViewModel = _mapper.Map<EscolaViewModel>(escola);
            return View(escolaViewModel);
        }

        // POST: EscolaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EscolaViewModel escolaViewModel)
        {
            _escolaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
