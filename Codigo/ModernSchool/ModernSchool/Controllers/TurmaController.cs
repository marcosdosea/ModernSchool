using AutoMapper;
using Core.Service;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ITurmaService _turmaService;
        private readonly IMapper _mapper;

        public TurmaController(ITurmaService turmaService, IMapper mapper)
        {
            _turmaService = turmaService;
            _mapper = mapper;
        }

        // GET: TurmaController
        public ActionResult Index()
        {
            var listaTurma = _turmaService.GetAll();
            var listaTurmaModel = _mapper.Map<List<TurmaViewModel>>(listaTurma);
            return View(listaTurmaModel);
        }

        // GET: TurmaController/Details/5
        public ActionResult Details(int id)
        {
            Turma turma = _turmaService.Get(id);
            TurmaViewModel turmaModel = _mapper.Map<TurmaViewModel>(turma);
            return View(turmaModel);
        }

        // GET: TurmaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TurmaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TurmaViewModel turmaViewModel)
        {
            if (ModelState.IsValid)
            {
                var turma = _mapper.Map<Turma>(turmaViewModel);
                _turmaService.Create(turma);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TurmaController/Edit/5
        public ActionResult Edit(int id)
        {
            Turma turma = _turmaService.Get(id);
            TurmaViewModel turmaModel = _mapper.Map<TurmaViewModel>(turma);
            return View(turmaModel);
        }

        // POST: TurmaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TurmaViewModel turmaViewModel)
        {
            if (ModelState.IsValid)
            {
                var turma = _mapper.Map<Turma>(turmaViewModel);
                _turmaService.Edit(turma);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TurmaController/Delete/5
        public ActionResult Delete(int id)
        {
            Turma turma = _turmaService.Get(id);
            TurmaViewModel turmaViewModel = _mapper.Map<TurmaViewModel>(turma);
            return View(turmaViewModel);
        }

        // POST: TurmaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TurmaViewModel turmaViewModel)
        {
            _turmaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
