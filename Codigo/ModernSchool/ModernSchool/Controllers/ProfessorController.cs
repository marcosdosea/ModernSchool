using AutoMapper;
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
            DiarioDeClasseViewModel diario = new DiarioDeClasseViewModel();

            diario.IdProfessor = idProfessor;
            diario.IdComponente = idComponente;
            diario.IdTurma = idTurma;
            diario.Habilidade = _diarioDeClasseService.GetAllHabilidade().ToList();
            string nomeComponente = _componenteService.Get(idComponente).Nome;
            string nomeTurma = _turmaService.Get(idTurma).Turma1;
            ViewData["nomeTurma"] = nomeTurma;
            ViewData["nomeComponente"] = nomeComponente;
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

            var listAluno = _frequenciaAlunoService.GetAllFrequenciaAlunoDTO(IdDiario);
            var listModel = _mappers.Map<List<FrequenciaAlunoDTOViewModel>>(listAluno);

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


            return RedirectToAction(nameof(DiarioDeClasse), new { idTurma = frequenciaAluno.IdTurma, idComponente = frequenciaAluno.IdComponente });
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
