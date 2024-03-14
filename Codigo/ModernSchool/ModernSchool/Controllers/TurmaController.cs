using AutoMapper;
using Core.Service;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ModernSchoolWEB.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ITurmaService _turmaService;
        private readonly IMapper _mapper;
        private readonly IAnoLetivoService _anoLetivoService;
        private readonly IEscolaService _escolaService;
        public TurmaController(ITurmaService turmaService, IAnoLetivoService anoLetivoService,
            IMapper mapper, IEscolaService escolaService)
        {
            _turmaService = turmaService;
            _anoLetivoService = anoLetivoService;
            _mapper = mapper;
            _escolaService = escolaService;
        }

        // GET: TurmaController
        public ActionResult Index()
        {
            var listaTurma = _turmaService.GetAll();
            var listaTurmaModel = _mapper.Map<List<TurmaViewModel>>(listaTurma);

            foreach (var turmaViewModel in listaTurmaModel)
            {
                turmaViewModel.ListaTurma = _mapper.Map<List<TurmaViewModel>>(_turmaService.GetAll());
            }
            TurmaViewModel turma =  new TurmaViewModel()
            {
                ListaTurma = listaTurmaModel
            };
            var anoLetivo = _anoLetivoService.GetAll();
            turma.ListaAnoLetivo = new SelectList(anoLetivo, "AnoLetivo1", "AnoLetivo1", null);
            return View(turma);
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
            TurmaViewModel viewModel = new();
            var anoLetivo = _anoLetivoService.GetAll();
            viewModel.ListaAnoLetivo = new SelectList(anoLetivo, "AnoLetivo1", "AnoLetivo1", null);
            viewModel.NomeEscola = _escolaService.GetNomeEscola(Convert.ToInt32(User.FindFirst("Id")?.Value));
            return View(viewModel);
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
        /*public ActionResult Delete(int id)
        {
            Turma turma = _turmaService.Get(id);
            TurmaViewModel turmaViewModel = _mapper.Map<TurmaViewModel>(turma);
            return View(turmaViewModel);
        }
        */
        // POST: TurmaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TurmaViewModel turmaViewModel)
        {
            _turmaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }


        // GET: TurmaController
        /*public ActionResult Index()
        {
            var listaEscolas = _turmaService.EscolaVinculadaProfessor();
            var listaEscolaProfessorDTOModel = _mapper.Map<List<EscolaProfessorDTOViewModel>>(listaEscolas);
            return View(listaEscolaProfessorDTOModel);
        }*/

    }
}
