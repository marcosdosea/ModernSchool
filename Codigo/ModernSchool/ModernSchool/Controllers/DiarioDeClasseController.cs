using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;
using Service;

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
            return View();
        }

        // GET: DiarioDeClasseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiarioDeClasseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DiarioDeClasseViewModel diarioDeClasseModel)
        {

            if (ModelState.IsValid)
            {
                var diarioClasse = _mapper.Map<Diariodeclasse>(diarioDeClasseModel);
                _diarioDeClasseService.Create(diarioClasse);

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DiarioDeClasseController/Edit/5
        public ActionResult Edit(int id)
        {
            Diariodeclasse diarioDeClasse = _diarioDeClasseService.Get(id);
            DiarioDeClasseViewModel diarioDeclasseModel= _mapper.Map<DiarioDeClasseViewModel>(diarioDeClasse);
            return View(diarioDeclasseModel);

        }

        // POST: DiarioDeClasseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DiarioDeClasseViewModel diarioDeClasseModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var diarioDeClasse = _mapper.Map<Diariodeclasse>(diarioDeClasseModel);
                    _diarioDeClasseService.Edit(diarioDeClasse);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiarioDeClasseController/Delete/5
        public ActionResult Delete(int id)
        {
            Diariodeclasse diarioDeClasse = _diarioDeClasseService.Get(id);
            DiarioDeClasseViewModel diarioDeclasseModel = _mapper.Map<DiarioDeClasseViewModel>(diarioDeClasse);
            return View(diarioDeclasseModel);

        }

        // POST: DiarioDeClasseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DiarioDeClasseViewModel diarioDeClasseModel)
        {
                _diarioDeClasseService.Delete(id);
                return RedirectToAction(nameof(Index));
        }
    }
}
