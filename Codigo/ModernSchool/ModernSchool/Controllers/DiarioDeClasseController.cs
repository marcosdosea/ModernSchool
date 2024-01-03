using AutoMapper;
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModernSchoolWEB.Models;
using Service;

namespace ModernSchoolWEB.Controllers
{
    public class DiarioDeClasseController : Controller
    {
        private readonly IDiarioDeClasseService _diarioDeClasseService;
        private readonly IMapper _mapper;
        private readonly IComponenteService _componenteService;
        private readonly IPessoaService _pessoaService;
        readonly ITurmaService _turmaService;
        public DiarioDeClasseController(IDiarioDeClasseService diarioDeClasseService, IMapper mapper, IComponenteService componenteService, IPessoaService pessoaService, ITurmaService turmaService)
        {
            _diarioDeClasseService = diarioDeClasseService;
            _mapper = mapper;
            _componenteService = componenteService;
            _pessoaService = pessoaService;
            _turmaService = turmaService;
        }

        // GET: DiarioDeClasseController
        public ActionResult Index()
        {
           return View();
        }

        // GET: DiarioDeClasseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DiarioDeClasseController/Create
        public ActionResult Create()
        {
            DiarioDeClasseViewModel diarioModel = new DiarioDeClasseViewModel();

            IEnumerable<PessoaProfessorDTO> listaProfessor = _pessoaService.GetAllProfessor();
            IEnumerable<Componente> listaComponente = _componenteService.GetAll();
            IEnumerable<Turma> listaTurma = _turmaService.GetAll();

            diarioModel.listaTurma = new SelectList(listaTurma, "Id", "Turma1", null);
            diarioModel.listaProfessor = new SelectList(listaProfessor, "IdPessoa", "NomePessoa", null);
            diarioModel.listaComponente = new SelectList(listaComponente, "Id", "Nome", null);




            return View(diarioModel);
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
            DiarioDeClasseViewModel diarioModel = _mapper.Map<DiarioDeClasseViewModel>(diarioDeClasse);

            IEnumerable<PessoaProfessorDTO> listaProfessor = _pessoaService.GetAllProfessor();
            IEnumerable<Componente> listaComponente = _componenteService.GetAll();
            IEnumerable<Turma> listaTurma = _turmaService.GetAll();

            diarioModel.listaTurma = new SelectList(listaTurma, "Id", "Turma1", null);
            diarioModel.listaProfessor = new SelectList(listaProfessor, "IdPessoa", "NomePessoa", null);
            diarioModel.listaComponente = new SelectList(listaComponente, "Id", "Nome", null);

            return View(diarioModel);

        }

        // POST: DiarioDeClasseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DiarioDeClasseViewModel diarioDeClasseModel)
        {
            

            if (ModelState.IsValid)
            {
                var diarioDeClasse = _mapper.Map<Diariodeclasse>(diarioDeClasseModel);
                _diarioDeClasseService.Edit(diarioDeClasse);
            }
            return RedirectToAction(nameof(Index));



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
