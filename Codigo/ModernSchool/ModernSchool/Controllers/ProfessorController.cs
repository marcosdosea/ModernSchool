﻿using AutoMapper;
using Core;
using Core.DTO;
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
        private readonly IFrequenciaAlunoService _frequenciaAlunoService;
        private readonly IMapper _mappers;

        public ProfessorController(IGradeHorarioService gradeHorario,
            IMapper mappers, IDiarioDeClasseService diarioDeClasseService,
            IFrequenciaAlunoService frequenciaAlunoService)
        {
            _gradeHorario = gradeHorario;
            _mappers = mappers;
            _diarioDeClasseService = diarioDeClasseService;
            _frequenciaAlunoService = frequenciaAlunoService;
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

            diario.Habilidade = _diarioDeClasseService.GetAllHabilidade().ToList();
            return View(diario);
        }

        // POST: ProfessorController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDiarioClasse(DiarioDeClasseViewModel diarioDeClasse)
        {

            foreach(var list in diarioDeClasse.Habilidade)
            {
                if (list.Selecionado)
                {
                    Diariodeclasse diario = new Diariodeclasse
                    {
                        DataShow = diarioDeClasse.DataShow,
                        IdComponente = diarioDeClasse.IdComponente,
                        IdProfessor = diarioDeClasse.IdProfessor,
                        Livros = diarioDeClasse.Livros,
                        LivrosSeduc = diarioDeClasse.LivrosSeduc,
                        IdTurma = diarioDeClasse.IdTurma,
                        ResumoAula = diarioDeClasse.ResumoAula,
                        TipoAula = diarioDeClasse.TipoAula,
                    };

                    _diarioDeClasseService.CreateDiarioClasse(diario, list);
                }
            }




            
            try
            {
                return RedirectToAction(nameof(DiarioDeClasse));
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Frequencia(int IdDiario)
        {

            var listAluno = _frequenciaAlunoService.GetAllFrequenciaAlunoDTO();
            var listModel = _mappers.Map<List<FrequenciaAlunoDTOViewModel>>(listAluno);

            foreach (var item in listModel)
            {
                item.IdDiario = IdDiario;
            }

            return View(listModel);
        }

        [HttpPost]
        public ActionResult SalvarFrequencia(List<FrequenciaAlunoDTOViewModel> frequenciaAluno)
        {


            foreach (var item in frequenciaAluno)
            {
                Frequenciaaluno freuqencia = new Frequenciaaluno
                {
                    Faltas = item.Faltas,
                    IdAluno = item.IdAluno,
                    IdDiarioDeClasse = item.IdDiario
                };

                _frequenciaAlunoService.Create(freuqencia);

            }

            return View(frequenciaAluno);
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
