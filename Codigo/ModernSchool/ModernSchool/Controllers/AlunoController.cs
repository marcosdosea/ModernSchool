using AutoMapper;
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Controllers
{
    [Authorize(Roles = "ALUNO")]
    public class AlunoController : Controller
    {

        private readonly IPessoaService _pessooaService;
        private readonly IGradeHorarioService _gradeHorarioService;
        private readonly ITurmaService _turmaService;
        private readonly IAvaliacaoService _avaliacaoService;
        private readonly IDiarioDeClasseService _diarioDeClasseService;
        private readonly IComponenteService _componenteService;
        private readonly IMapper _mapper;
        private readonly IPeriodoService _periodoService;
        private readonly IComunicacaoService _comunicacaoService;

        public AlunoController(IPessoaService pessooaService, IGradeHorarioService gradeHorarioService,
            IMapper mapper, ITurmaService turmaService, IAvaliacaoService avaliacaoService,
            IDiarioDeClasseService diarioDeClasseService,
            IComponenteService componenteService, IPeriodoService periodo,
            IComunicacaoService comunicacaoService)
        {
            _pessooaService = pessooaService;
            _gradeHorarioService = gradeHorarioService;
            _mapper = mapper;
            _turmaService = turmaService;
            _avaliacaoService = avaliacaoService;
            _diarioDeClasseService = diarioDeClasseService;
            _componenteService = componenteService;
            _periodoService = periodo;
            _comunicacaoService = comunicacaoService;
        }

        public ActionResult Index()
        {

            int idAluno = Convert.ToInt32(User.FindFirst("Id")?.Value);
            Alunoturma aluno = _pessooaService.GetAlunoTurma(idAluno);
            var listaComponentes = _pessooaService.GetListasComponente(aluno.IdTurma);
            var listaAvaliacao = _avaliacaoService.GetAlunoAtividades(aluno.IdTurma, idAluno);
            AlunoTelaIndex telaAluno = new();

            for (int i = 0; i < listaComponentes.Count(); i++)
            {
                Horarios horarios = new Horarios();
                horarios.NomeComponente = listaComponentes[i].NomeComponente;
                for (int j = 0; j < listaComponentes.Count(); j++)
                {
                    if (horarios.NomeComponente == listaComponentes[j].NomeComponente)
                    {
                        string horario = "<strong>" + (listaComponentes[j].DiaSemana ?? "") + "</strong>" + " - " +
                                         (listaComponentes[j].HoraInicio.Substring(0, 2) ?? "") + ":" +
                                         (listaComponentes[j].HoraInicio.Substring(2, 2) ?? "") + " - " +
                                         (listaComponentes[j].HoraFim.Substring(0, 2) ?? "") + ":" +
                                         (listaComponentes[j].HoraFim.Substring(2, 2) ?? "");
                        if (horarios.Horas == null)
                        {
                            horarios.Horas = new List<string>();
                        }
                        horarios.Horas.Add(horario);
                    }
                }
                listaComponentes[i].HorarioComponente = horarios;
                listaComponentes[i].HorarioComponente.Local = listaComponentes[i].Local;
                listaComponentes[i].HorarioComponente.IdComponente = listaComponentes[i].IdComponente;
                if (telaAluno.AlunosDisciplinas == null)
                {
                    telaAluno.AlunosDisciplinas = new List<Horarios>();
                }
                if (!telaAluno.AlunosDisciplinas.Any(g => g.NomeComponente == horarios.NomeComponente))
                {
                    telaAluno.AlunosDisciplinas.Add(listaComponentes[i].HorarioComponente);
                }
            }

            telaAluno.IdTurma = aluno.IdTurma;
            telaAluno.IdAluno = aluno.IdAluno;
            telaAluno.NomeTurma = _turmaService.Get(aluno.IdTurma).Turma1;

            telaAluno.AlunosAtividade = listaAvaliacao;
            return View(telaAluno);
        }

        public ActionResult AtividadesComponentes(int idComponente, int idAluno, int idTurma)
        {

            AvaliacaoComponente view = new();
            var diarioAluno = _diarioDeClasseService.GetDiarioAlunos(idTurma, idComponente);

            foreach (var item in diarioAluno)
            {
                item.Falta = _diarioDeClasseService.GetFaltaAluno(idAluno, item.IdDiario);
            }
            view.DiarioAlunos = diarioAluno;
            view.NomeComponente = _componenteService.Get(idComponente).Nome;
            view.IdComponente = idComponente;
            view.IdTurma = idTurma;
            return View(view);
        }

        public ActionResult NotasAluno(int IdTurma)
        {

            var periodos = _periodoService.GetAll().ToList();
            var componentes = _componenteService.GetAll().ToList();
            int idAluno = Convert.ToInt32(User.FindFirst("Id")?.Value);
            NotasAlunoModel model = new NotasAlunoModel();  
            model.Componentes = new List<ComponenteNota>();
            model.PeriodosNotas = new List<PeriodoNota>();
            model.IdTurma = IdTurma;
            
            for (int i = 0; i < componentes.Count(); i++)
            {
                ComponenteNota componente = new ComponenteNota()
                {
                    IdComponente = componentes[i].Id,
                    NomeComponente = componentes[i].Nome
                };
                model.Componentes.Add(componente);
                for (int j = 0; j < periodos.Count(); j++)
                {
                    decimal nota = _avaliacaoService.GetNotaPeriodo(idAluno, IdTurma, periodos[j].Id, componentes[i].Id);
                    string periodo = periodos[j].Nome;
                    PeriodoNota notasPeriodo = new()
                    {
                        Nota = nota,
                        PeriodoAvaliacao = periodo,
                        IdComponente = componentes[i].Id
                    };
                    model.PeriodosNotas.Add(notasPeriodo);
                }
            }



            return View(model);
        }


        public ActionResult ComunicadoAluno(int idTurma)
        {
            int idAluno = Convert.ToInt32(User.FindFirst("Id")?.Value);

            AlunoComunicacaoIndexDTO comunicado = new();
            comunicado.Comunicados = _comunicacaoService.ComunicacaoAluno(idAluno,idTurma);
            comunicado.IdTurma = idTurma;
            comunicado.NomeTurma = _turmaService.Get(idTurma).Turma1;
            return View(comunicado);
        }



    }
}
