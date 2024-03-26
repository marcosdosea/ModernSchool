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
        private readonly ITurmaService _turmaService;
        private readonly IPeriodoService _periodoService;

        private readonly IMapper _mapper;

        public AvaliacaoController(IAvaliacaoService avaliacaoService, IComponenteService componenteService,
                                   IMapper mapper, IAlunoAvaliacaoService alunoAvaliacaoService, ITurmaService turmaService,
                                   IPeriodoService periodoService)
        {
            _avaliacaoService = avaliacaoService;
            _componenteService = componenteService;
            _mapper = mapper;
            _alunoAvaliacaoService = alunoAvaliacaoService;
            _turmaService = turmaService;
            _periodoService = periodoService;
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
            ViewData["Turma"] = _turmaService.Get(idTurma).Turma1;
            ViewData["Componente"] = _componenteService.Get(idComponente).Nome; ;
            return View(viewModel);
        }

        public ActionResult AdicionarNotasAvaliacao(int idAvaliacao, int idComponente)
        {
            ViewData["FlagLyoutProf"] = true;
            int idTurma = _avaliacaoService.Get(idAvaliacao).IdTurma;
            ViewData["Turma"] = _turmaService.Get(idTurma).Turma1;
            ViewData["Componente"] = _componenteService.Get(idComponente).Nome;
            AlunoAvaliacaoNotasDTOViewModel viewModel = new AlunoAvaliacaoNotasDTOViewModel();

            var listaForAvaliacao = _avaliacaoService.GetAllAlunosAvaliacao(idTurma, idAvaliacao);

            viewModel.ListaAluno = listaForAvaliacao;
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
                alunoAvaliacao.Nota = item.Notas;
                _alunoAvaliacaoService.Edit(alunoAvaliacao);

            }

            return RedirectToAction(nameof(Index), new { idTurma = viewModel.IdTurma, idComponente = viewModel.IdComponente  });
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
            ViewData["Turma"] = _turmaService.Get(idTurma).Turma1;
            ViewData["Componente"] = _componenteService.Get(idComponente).Nome;

            AvaliacaoViewModel avaliacaoViewModel = new AvaliacaoViewModel();
            avaliacaoViewModel.IdTurma = idTurma;
            avaliacaoViewModel.IdComponente = idComponente;
            IEnumerable<Componente> listaComponenstes = _componenteService.GetAll();
            IEnumerable<Turma> listaTurma = _turmaService.GetAll();
            IEnumerable<Periodo> listaPeriodo = _periodoService.GetAll();
            avaliacaoViewModel.listaPeriodo = new SelectList(listaPeriodo, "Id", "Nome", null);

            return View(avaliacaoViewModel);
        }

        // POST: AvaliacaoController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AvaliacaoViewModel avaliacaoModel)
        {
            if(avaliacaoModel.Arquivo == null)
            {
                ModelState.Remove("Arquivo");
            }
            if (ModelState.IsValid)
            {
                var avaliacao = _mapper.Map<Avaliacao>(avaliacaoModel);
                int idAvaliacao = _avaliacaoService.Create(avaliacao);
                if (idAvaliacao != 0)
                {
                    var listaForTurma = _avaliacaoService.GetAllAlunos(avaliacaoModel.IdTurma);
                    MemoryStream ms = new();
                    avaliacaoModel.Arquivo.CopyTo(ms);
                    byte[] arquivo = ms.ToArray();
                    Alunoavaliacao alunoAvaliacao = new();
                    foreach (var item in listaForTurma)
                    {
                        alunoAvaliacao = _alunoAvaliacaoService.Get(item.IdAluno, idAvaliacao);
                        if (alunoAvaliacao == null)
                        {

                            alunoAvaliacao = new Alunoavaliacao
                            {
                                Arquivo = arquivo,
                                DataEntrega = DateTime.Now,
                                IdAluno = item.IdAluno,
                                IdAvaliacao = idAvaliacao,
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

                }
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
