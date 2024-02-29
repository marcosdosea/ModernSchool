using AutoMapper;
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModernSchoolWEB.Models;
using Service;
using System.Text;

namespace ModernSchoolWEB.Controllers
{
    public class AvaliacaoController : Controller
    {

        private readonly IAvaliacaoService _avaliacaoService;
        private readonly IComponenteService _componenteService;
        private readonly IAlunoAvaliacaoService _alunoAvaliacaoService;
        //private readonly ITurmaService _turmaService;
        //private readonly IPessoaService _pessoaService;

        private readonly IMapper _mapper;

        public IAvaliacaoService Object { get; }
        public IMapper Mapper { get; }

        public AvaliacaoController(IAvaliacaoService avaliacaoService,
            IComponenteService componenteService, IMapper mapper,IAlunoAvaliacaoService alunoAvaliacaoService) 
        {
            _avaliacaoService = avaliacaoService;
            _componenteService = componenteService;
            _mapper = mapper;
            _alunoAvaliacaoService = alunoAvaliacaoService;
        }

        // GET: AvaliacaoController1
        public ActionResult Index(int idTurma, int idComponente)
        {
            ViewData["FlagLyoutProf"] = true;
            var avaliacoes = _avaliacaoService.GetAllDTO(idTurma, idComponente);

            AvaliacaoProfessorViewModel viewModel = new AvaliacaoProfessorViewModel();

            viewModel.Avalicoes = avaliacoes;
            viewModel.IdComponente = idComponente;
            viewModel.IdTurma = idTurma;
            return View(viewModel);
        }

        public ActionResult AdicionarNotasAvaliacao(int idAvaliacao, int idComponente)
        {
            int idTurma = _avaliacaoService.Get(idAvaliacao).IdTurma;
            AlunoAvaliacaoNotasDTOViewModel viewModel = new AlunoAvaliacaoNotasDTOViewModel();

            var listaForAvaliacao = _avaliacaoService.GetAllAlunosAvaliacao(idTurma, idAvaliacao);
            if(listaForAvaliacao.Count() !=  0)
            {
                viewModel.ListaAluno = listaForAvaliacao;
            }
            else
            {
                var listaForTurma = _avaliacaoService.GetAllAlunos(idTurma);
                viewModel.ListaAluno = listaForTurma;
            }

            viewModel.Idavaliacao = idAvaliacao;
            viewModel.IdTurma = idTurma;
            viewModel.IdComponente = idComponente;

            return View(viewModel);
        }

        [HttpPost]

        public ActionResult AdicionarNotasAvaliacao(AlunoAvaliacaoNotasDTOViewModel viewModel)
        {


            Alunoavaliacao alunoAvaliacao = new();

            foreach (var item in viewModel.ListaAluno)
            {
                alunoAvaliacao = _alunoAvaliacaoService.Get(item.IdAluno, viewModel.Idavaliacao);
                if (alunoAvaliacao == null)
                {

                    alunoAvaliacao = new Alunoavaliacao
                    {
                        Arquivo = Encoding.ASCII.GetBytes("t"),
                        DataEntrega = DateTime.Now,
                        IdAluno = item.IdAluno,
                        IdAvaliacao = viewModel.Idavaliacao,
                        Nota = item.Notas

                    };
                    _alunoAvaliacaoService.Create(alunoAvaliacao);
                }
                else
                {
                    alunoAvaliacao.Nota = item.Notas;
                    _alunoAvaliacaoService.Edit(alunoAvaliacao);
                }
            }

            return RedirectToAction(nameof(Index), new {idComponente = viewModel.IdComponente , idTurma = viewModel.IdComponente});
        }


        // GET: AvaliacaoController1/Details/5
        public ActionResult Details(int id)
        {
            Avaliacao avaliacao = _avaliacaoService.Get(id);
            AvaliacaoViewModel avaliacaoModel = _mapper.Map<AvaliacaoViewModel>(avaliacao);

            return View(avaliacaoModel);
        }

        // GET: AvaliacaoController1/Create
        public ActionResult Create(int idTurma, int idComponente)
        {
            ViewData["FlagLyoutProf"] = true;

            AvaliacaoViewModel avaliacaoViewModel = new AvaliacaoViewModel();
            avaliacaoViewModel.IdTurma = idTurma;
            avaliacaoViewModel.IdComponente = idComponente;
            IEnumerable<Componente> listaComponenstes = _componenteService.GetAll();

            avaliacaoViewModel.ListaComponentes = new SelectList(listaComponenstes, "Id", "Nome", null);

            return View(avaliacaoViewModel);
        }

        // POST: AvaliacaoController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AvaliacaoViewModel avaliacaoModel)
        {
            if (ModelState.IsValid)
            {
                var avaliacao = _mapper.Map<Avaliacao>(avaliacaoModel);
                _avaliacaoService.Create(avaliacao);

            }
            return RedirectToAction(nameof(Index), new { idTurma = avaliacaoModel.IdTurma, idComponente = avaliacaoModel.IdComponente });
        }

        // GET: AvaliacaoController1/Edit/5
        public ActionResult Edit(int id)
        {
            Avaliacao avaliacao = _avaliacaoService.Get(id);
            AvaliacaoViewModel avaliacaoModel = _mapper.Map<AvaliacaoViewModel>(avaliacao);

            return View(avaliacaoModel);
        }

        // POST: AvaliacaoController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AvaliacaoViewModel avaliacaoModel)
        {
            if (ModelState.IsValid)
            {
                var avaliacao = _mapper.Map<Avaliacao>(avaliacaoModel);
                _avaliacaoService.Edit(avaliacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AvaliacaoController1/Delete/5
        public ActionResult Delete(int id)
        {
            Avaliacao avaliacao = _avaliacaoService.Get(id);
            AvaliacaoViewModel avaliacaoModel = _mapper.Map<AvaliacaoViewModel>(avaliacao);

            return View(avaliacaoModel);
        }

        // POST: AvaliacaoController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AvaliacaoViewModel avaliacaoModel)
        {

            _avaliacaoService.Delete(id);


            return RedirectToAction(nameof(Index));

        }
    }
}
