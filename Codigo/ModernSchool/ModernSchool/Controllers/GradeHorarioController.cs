using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ModernSchoolWEB.Models;
using Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModernSchoolWEB.Controllers
{

    public class GradeHorarioController : Controller
    {
        private readonly IGradeHorarioService _gradehorarioService;
        private readonly IMapper _mapper;
        private readonly IComponenteService _componenteService;
        private readonly ITurmaService _turmaService; 
        private readonly IPessoaService _pessoaService;
        private readonly IEscolaService _escolaService;

        public GradeHorarioController(IGradeHorarioService gradehorario, IMapper mapper
            , IComponenteService componenteService, ITurmaService turmaService,IPessoaService pessoaService
            , IEscolaService escolaService)
        {
            _gradehorarioService = gradehorario;
            _mapper = mapper;
            _componenteService = componenteService;
            _turmaService = turmaService;
            _pessoaService = pessoaService;
            _escolaService = escolaService;
        }

        public ActionResult Index(int idTurma)
        {
            var listaGrade = _gradehorarioService.GetAllGradeHorario();
            GradeHorarioDTOModel view = new();
            view.GradeHorarioDTOs = listaGrade.ToList();
            view.IdTurma = idTurma;
            view.NomeTurma = _turmaService.Get(idTurma).Turma1;
            return View(view);
        }


        public ActionResult Details(int id)
        {
            GradeHorarioDTO? detalhesProfessor = _gradehorarioService.GetAGradeHorario(id);
            GradeHorarioDTOModel model = _mapper.Map<GradeHorarioDTOModel>(detalhesProfessor);
            return View(model);
        }

        public ActionResult Create(int idTurma)
        {
            GradehorarioViewModel gradehorarioViewModel = new GradehorarioViewModel();

            var turma = _turmaService.Get(idTurma);
            string nomeEscola = _escolaService.GetNomeEscola(Convert.ToInt32(User.FindFirst("Id")?.Value));
               
            IEnumerable<Componente> listaComponenstes = _componenteService.GetAll();
            IEnumerable<PessoaProfessorDTO> listaProfessor = _pessoaService.GetAllProfessor();
            
            gradehorarioViewModel.ListaComponentes = new SelectList(listaComponenstes, "Id", "Nome",null);
            gradehorarioViewModel.ListaProfessor = new SelectList(listaProfessor, "IdPessoa", "NomePessoa",null);
            gradehorarioViewModel.Turma = turma.Turma1;
            gradehorarioViewModel.Sala = turma.Sala;
            gradehorarioViewModel.NomeEscola = nomeEscola;
            gradehorarioViewModel.IdTurma = idTurma;


            return View(gradehorarioViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GradehorarioViewModel gradehorarioModel)
        {
            ModelStateDictionary modelStateClone = new ModelStateDictionary();
            foreach (var entry in ModelState)
            {
                modelStateClone.SetModelValue(entry.Key, entry.Value.RawValue, entry.Value.AttemptedValue);
            }
            modelStateClone.Remove("Sala");
            modelStateClone.Remove("Turma");
            modelStateClone.Remove("NomeEscola");
            foreach (var entry in modelStateClone)
            {
                entry.Value.ValidationState = ModelValidationState.Valid;
            }
            if (modelStateClone.IsValid)
            {
                var gradeHorario = _mapper.Map<Gradehorario>(gradehorarioModel);
                gradeHorario.HoraInicio = gradeHorario.HoraInicio.Replace(":", "");
                gradeHorario.HoraFim = gradeHorario.HoraFim.Replace(":", "");
                _gradehorarioService.Create(gradeHorario);
            }
            return RedirectToAction(nameof(Index),new {idTurma = gradehorarioModel.IdTurma});
        }

        public ActionResult Edit(int id)
        {
            Gradehorario gradehorario = _gradehorarioService.Get(id);
            GradehorarioViewModel gradehorarioModel = _mapper.Map<GradehorarioViewModel>(gradehorario);

            IEnumerable<Turma> listaTurmas = _turmaService.GetAll();
            IEnumerable<Componente> listaComponenstes = _componenteService.GetAll();
            IEnumerable<PessoaProfessorDTO> listaProfessor = _pessoaService.GetAllProfessor();

            gradehorarioModel.ListaComponentes = new SelectList(listaComponenstes, "Id", "Nome", null);
            gradehorarioModel.ListaTurma = new SelectList(listaTurmas, "Id", "Turma1");
            gradehorarioModel.ListaProfessor = new SelectList(listaProfessor, "IdPessoa", "NomePessoa");

            return View(gradehorarioModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GradehorarioViewModel gradehorarioModel)
        {
            ModelStateDictionary modelStateClone = new ModelStateDictionary();
            foreach (var entry in ModelState)
            {
                modelStateClone.SetModelValue(entry.Key, entry.Value.RawValue, entry.Value.AttemptedValue);
            }
            modelStateClone.Remove("Sala");
            modelStateClone.Remove("Turma");
            modelStateClone.Remove("NomeEscola");
            foreach (var entry in modelStateClone)
            {
                entry.Value.ValidationState = ModelValidationState.Valid;
            }


            gradehorarioModel.HoraInicio = gradehorarioModel.HoraInicio.Replace(":", "");
            gradehorarioModel.HoraFim = gradehorarioModel.HoraFim.Replace(":", "");
            if (modelStateClone.IsValid)
            {
                Gradehorario gradehorario = _mapper.Map<Gradehorario>(gradehorarioModel);
                _gradehorarioService.Edit(gradehorario);
            }

            return RedirectToAction(nameof(Index), new {gradehorarioModel.IdTurma});

        }

        public ActionResult Delete(int id)
        {
            GradeHorarioDTO? detalhesProfessor = _gradehorarioService.GetAGradeHorario(id);
            GradeHorarioDTOModel model = _mapper.Map<GradeHorarioDTOModel>(detalhesProfessor);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,GradehorarioViewModel gradehorarioModel )
        {
            _gradehorarioService.Delete(id);
            return RedirectToAction(nameof(Index), new {gradehorarioModel.IdTurma}); 
        }
    }
}
