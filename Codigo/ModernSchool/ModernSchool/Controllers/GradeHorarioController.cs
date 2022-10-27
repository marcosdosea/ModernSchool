using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ModernSchoolWEB.Models;
using Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.DTO;

namespace ModernSchool.Controllers
{

    public class GradeHorarioController : Controller
    {
        private readonly IGradeHorarioService _gradehorarioService;
        private readonly IMapper _mapper;
        private readonly IComponenteService _componenteService;
        private readonly ITurmaService _turmaService; 
        private readonly IPessoaService _pessoaService;

        public GradeHorarioController(IGradeHorarioService gradehorario, IMapper mapper
            , IComponenteService componenteService, ITurmaService turmaService,IPessoaService pessoaService)
        {
            _gradehorarioService = gradehorario;
            _mapper = mapper;
            _componenteService = componenteService;
            _turmaService = turmaService;
            _pessoaService = pessoaService;
        }

       /* public ActionResult Index()
        {
            var listaGradeHorario = _gradehorarioService.GetAll();
            var listaGradeHorarioModel = _mapper.Map<List<GradehorarioViewModel>>(listaGradeHorario);

            return View(listaGradeHorarioModel);
        }*/

        public ActionResult Index()
        {
            var listaGrade = _gradehorarioService.GetAllGradeHorario();
            var listaModel = _mapper.Map<List<GradeHorarioDTOModel>>(listaGrade);
            return View(listaModel);
        }


        public ActionResult Details(int id)
        {
            GradeHorarioDTO? detalhesProfessor = _gradehorarioService.GetAGradeHorario(id);
            GradeHorarioDTOModel model = _mapper.Map<GradeHorarioDTOModel>(detalhesProfessor);
            return View(model);
        }

        public ActionResult Create()
        {
            GradehorarioViewModel gradehorarioViewModel = new GradehorarioViewModel();

            IEnumerable<Turma> listaTurmas = _turmaService.GetAll();
            IEnumerable<Componente> listaComponenstes = _componenteService.GetAll();
            IEnumerable<PessoaProfessorDTO> listaProfessor = _pessoaService.GetAllProfessor();
            
            gradehorarioViewModel.ListaComponentes = new SelectList(listaComponenstes, "Id", "Nome",null);
            gradehorarioViewModel.ListaTurma = new SelectList(listaTurmas, "Id", "Turma1",null);
            gradehorarioViewModel.ListaProfessor = new SelectList(listaProfessor, "IdPessoa", "NomePessoa",null);



            return View(gradehorarioViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GradehorarioViewModel gradehorarioModel)
        {
            if (ModelState.IsValid)
            {
                var gradeHorario = _mapper.Map<Gradehorario>(gradehorarioModel);
                _gradehorarioService.Create(gradeHorario);
            }
            return RedirectToAction(nameof(Index));
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

            if (ModelState.IsValid)
            {
                Gradehorario gradehorario = _gradehorarioService.Get(id);
                _gradehorarioService.Edit(gradehorario);
            }

            return RedirectToAction(nameof(Index));

        }

        public ActionResult Delete(int id)
        {
            Gradehorario gradehorario = _gradehorarioService.Get(id);
            GradehorarioViewModel gradehorarioModel = _mapper.Map<GradehorarioViewModel>(gradehorario);
            return View(gradehorarioModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,GradehorarioViewModel gradehorarioModel )
        {
            _gradehorarioService.Delete(id);
            return RedirectToAction(nameof(Index)); 
        }
    }
}