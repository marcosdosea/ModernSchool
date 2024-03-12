using AutoMapper;
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Controllers
{
    public class AlunoController : Controller
    {

        private readonly IPessoaService _pessooaService;
        private readonly IGradeHorarioService _gradeHorarioService;
        private readonly ITurmaService _turmaService;
        private readonly IAvaliacaoService _avaliacaoService;
        private readonly IMapper _mapper;

        public AlunoController(IPessoaService pessooaService, IGradeHorarioService gradeHorarioService,
            IMapper mapper, ITurmaService turmaService,IAvaliacaoService avaliacaoService)
        {
            _pessooaService = pessooaService;
            _gradeHorarioService = gradeHorarioService;
            _mapper = mapper;
            _turmaService = turmaService;
            _avaliacaoService = avaliacaoService;
        }

        public IActionResult Index()
        {
            Alunoturma aluno = _pessooaService.GetAlunoTurma(2);
            var listaComponentes = _pessooaService.GetListasComponente(aluno.IdTurma);
            var listaAvaliacao = _avaliacaoService.GetAlunoAtividades(aluno.IdTurma);
            AlunoTelaIndex telaAluno = new();

            for(int i =0; i < listaComponentes.Count(); i++)
            {
                Horarios horarios = new Horarios();
                horarios.NomeComponente = listaComponentes[i].NomeComponente;
                for (int j = 0; j < listaComponentes.Count(); j++)
                {
                    if(horarios.NomeComponente == listaComponentes[j].NomeComponente)
                    {
                        string horario = listaComponentes[j].DiaSemana + " - " + listaComponentes[j].HoraInicio + " - " + listaComponentes[j].HoraFim;
                        if(horarios.Horas == null)
                        {
                            horarios.Horas = new List<string>();
                        }
                        horarios.Horas.Add(horario);
                    }
                }
                listaComponentes[i].HorarioComponente = horarios;
                listaComponentes[i].HorarioComponente.Local = listaComponentes[i].Local;
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




    }
}
