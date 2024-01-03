using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;
using Service;

namespace ModernSchoolWEB.Controllers
{
    public class ProfessorController : Controller
    {

        private readonly IGradeHorarioService _gradeHorario;
        private readonly IDiarioDeClasseService _diarioDeClasseService;
        private readonly IMapper _mappers;

        public ProfessorController(IGradeHorarioService gradeHorario, IMapper mappers,IDiarioDeClasseService diarioDeClasseService)
        {
            _gradeHorario = gradeHorario;
            _mappers = mappers;
            _diarioDeClasseService = diarioDeClasseService;
        }




        // GET: ProfessorController1
        public ActionResult Index()
        {
            var gradeHorario = _gradeHorario.GetAllGradeProfessor();
            return View(gradeHorario);
        }
        

        public ActionResult DiarioDeClasse(int idTurma, int idComponente)
        {

            var view = _diarioDeClasseService.GetAll();

            return View(view);
        }

        // GET: ProfessorController1/Create
        public ActionResult CreateDiarioClasse()
        {
            DiarioDeClasseViewModel diario = new DiarioDeClasseViewModel();

            diario.Habilidade = _diarioDeClasseService.GetAllHabilidade();
            return View();
        }

        // POST: ProfessorController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDiarioClasse(DiarioDeClasseViewModel DiarioDeClasse)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: ProfessorController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfessorController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfessorController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfessorController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfessorController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfessorController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfessorController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
