using AutoMapper;
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;
using Service;

namespace ModernSchoolWEB.Controllers
{
    [Authorize(Roles = "PROFESSOR")]
    public class ProfessorController : Controller
    {

        private readonly IGradeHorarioService _gradeHorario;
        private readonly IDiarioDeClasseService _diarioDeClasseService;
        private readonly IFrequenciaAlunoService _frequenciaAlunoService;
        private readonly IMapper _mappers;
        private readonly ITurmaService _turmaService;
        private readonly IComponenteService _componenteService;

        public ProfessorController(IGradeHorarioService gradeHorario,
            IMapper mappers, IDiarioDeClasseService diarioDeClasseService,
            IFrequenciaAlunoService frequenciaAlunoService,
            ITurmaService turmaService,
            IComponenteService componenteService)
        {
            _gradeHorario = gradeHorario;
            _mappers = mappers;
            _diarioDeClasseService = diarioDeClasseService;
            _frequenciaAlunoService = frequenciaAlunoService;
            _turmaService = turmaService;
            _componenteService = componenteService;
        }




        // GET: ProfessorController1
        public ActionResult Index()
        {
            ViewData["FlagLyoutProf"] = false;
            int idProfessor = Convert.ToInt32(User.FindFirst("Id")?.Value);
            var gradeHorario = _gradeHorario.GetAllGradeProfessor(idProfessor);
            return View(gradeHorario);
        }


        public ActionResult DiarioDeClasse(int idTurma, int idComponente)
        {
            ViewData["FlagLyoutProf"] = true;
            int idProfessor = Convert.ToInt32(User.FindFirst("Id")?.Value);
            string nomeComponente = _componenteService.Get(idComponente).Nome;
            string nomeTurma = _turmaService.Get(idTurma).Turma1;

            DiarioClasseProfessorDTO diario = new DiarioClasseProfessorDTO();
            var listaObjeto = _diarioDeClasseService.GetAllDiarioTurmaComponete(idProfessor, idComponente, idTurma);

            diario.ObjetoConhecimento = listaObjeto;
            diario.IdTurma = idTurma;
            diario.IdComponente = idComponente;
            diario.IdProfessor = idProfessor;
            diario.NomeComponente = nomeComponente;
            diario.NomeTurma = nomeTurma;


            return View(diario);
        }

        // GET: ProfessorController1/Create
        public ActionResult CreateDiarioClasse(int idTurma, int idProfessor, int idComponente)
        {
            ViewData["FlagLyoutProf"] = true;
            DiarioDeClasseViewModel diario = new DiarioDeClasseViewModel();

            diario.IdProfessor = idProfessor;
            diario.IdComponente = idComponente;
            diario.IdTurma = idTurma;
            diario.Habilidade = _diarioDeClasseService.GetAllHabilidade().ToList();

            ViewData["nomeTurma"] = _componenteService.Get(idComponente).Nome;
            ViewData["nomeComponente"] = _turmaService.Get(idTurma).Turma1;
            return View(diario);
        }

        // POST: ProfessorController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDiarioClasse(DiarioDeClasseViewModel diarioDeClasse)
        {

            foreach (var list in diarioDeClasse.Habilidade)
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
                        Data = diarioDeClasse.Data
                    };

                    _diarioDeClasseService.CreateDiarioClasse(diario, list);
                }
            }

            try
            {
                return RedirectToAction(nameof(DiarioDeClasse), new { idTurma = diarioDeClasse.IdTurma, idComponente = diarioDeClasse.IdComponente });
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Frequencia(int IdDiario, int IdTurma, int IdComponente)
        {
            ViewData["FlagLyoutProf"] = true;
            var listAluno = _frequenciaAlunoService.GetAllFrequenciaAlunoDTO(IdDiario);
            var listModel = _mappers.Map<List<FrequenciaAlunoDTOViewModel>>(listAluno);
            ViewData["Turma"] = _turmaService.Get(IdTurma).Turma1;
            ViewData["Componente"] = _componenteService.Get(IdComponente).Nome;

            FrequenciaListaAlunoDTOViewModel list = new FrequenciaListaAlunoDTOViewModel();
            list.IdTurma = IdTurma;
            list.IdComponente = IdComponente;
            list.Lista = listModel;


            foreach (var item in list.Lista)
            {
                item.IdDiario = IdDiario;
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult SalvarFrequencia(FrequenciaListaAlunoDTOViewModel frequenciaAluno)
        {

            if (ModelState.IsValid)
            {
                bool createNew = _frequenciaAlunoService.ExistFrequencia(frequenciaAluno.Lista[0].IdDiario);

                foreach (var item in frequenciaAluno.Lista)
                {
                    Frequenciaaluno freuqencia = new Frequenciaaluno
                    {
                        Faltas = item.Faltas,
                        IdAluno = item.IdAluno,
                        IdDiarioDeClasse = item.IdDiario
                    };
                    if (!createNew)
                    {
                        _frequenciaAlunoService.Create(freuqencia);
                    }
                    else
                    {
                        _frequenciaAlunoService.Edit(freuqencia);
                    }
                }
            }


            return RedirectToAction(nameof(DiarioDeClasse), new { idTurma = frequenciaAluno.IdTurma, idComponente = frequenciaAluno.IdComponente });
        }


        public ActionResult EditDiarioClasse(int IdDiario, int IdObjeto)
        {

            Core.Diariodeclasse diario = _diarioDeClasseService.Get(IdDiario);

            DiarioDeClasseViewModel diarioDeClasse = _mappers.Map<DiarioDeClasseViewModel>(diario);
            diarioDeClasse.ObjetoConhecimento = _diarioDeClasseService.GetObjetodeconhecimento(IdObjeto);
            diarioDeClasse.Id = IdDiario;

            //ViewData["Turma"] = _turmaService.Get(IdTurma).Turma1;
            //ViewData["Componente"] = _componenteService.Get(IdComponente).Nome;

            return View(diarioDeClasse);
        }

        [HttpPost]
        public ActionResult EditDiarioClasse(DiarioDeClasseViewModel diarioDeClasse)
        {
            ModelState.Remove("Habilidade");
            if (ModelState.IsValid)
            {
                Diariodeclasse diario = _mappers.Map<Diariodeclasse>(diarioDeClasse);

                _diarioDeClasseService.Edit(diario);
            }
            try
            {
                return RedirectToAction(nameof(DiarioDeClasse), new { idTurma = diarioDeClasse.IdTurma, idComponente = diarioDeClasse.IdComponente });
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDiarioClasse(DiarioDeClasseViewModel diarioDeClasse, int IdDiario, int IdObjeto) {
            
            diarioDeClasse = _mappers.Map<DiarioDeClasseViewModel>(_diarioDeClasseService.Get(IdDiario));
            _diarioDeClasseService.DeleteDiarioClasse(IdDiario, IdObjeto);

            return RedirectToAction(nameof(DiarioDeClasse), new { idTurma = diarioDeClasse.IdTurma, idComponente = diarioDeClasse.IdComponente });
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
