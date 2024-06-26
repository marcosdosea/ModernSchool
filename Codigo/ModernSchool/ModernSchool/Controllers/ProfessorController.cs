﻿using AutoMapper;
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;
using Org.BouncyCastle.Asn1.Mozilla;
using Service;
using static ModernSchoolWEB.Controllers.Notificacao;
using System.Net;

namespace ModernSchoolWEB.Controllers
{
    [Authorize(Roles = "PROFESSOR")]
    public class ProfessorController : Notificacao
    {

        private readonly IGradeHorarioService _gradeHorario;
        private readonly IDiarioDeClasseService _diarioDeClasseService;
        private readonly IFrequenciaAlunoService _frequenciaAlunoService;
        private readonly IMapper _mappers;
        private readonly ITurmaService _turmaService;
        private readonly IComponenteService _componenteService;
        private readonly IPessoaService _pessoaService;
        private readonly IComunicacaoService _comunicacaoService;

        public ProfessorController(IGradeHorarioService gradeHorario,
            IMapper mappers, IDiarioDeClasseService diarioDeClasseService,
            IFrequenciaAlunoService frequenciaAlunoService,
            ITurmaService turmaService,
            IComponenteService componenteService,
            IPessoaService pessoaService,
            IComunicacaoService comunicacaoService)
        {
            _gradeHorario = gradeHorario;
            _mappers = mappers;
            _diarioDeClasseService = diarioDeClasseService;
            _frequenciaAlunoService = frequenciaAlunoService;
            _turmaService = turmaService;
            _componenteService = componenteService;
            _pessoaService = pessoaService;
            _comunicacaoService = comunicacaoService;
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
            string[] anoFaixa = _turmaService.Get(idTurma).Turma1.Split(" ");
            anoFaixa[0] = System.Text.RegularExpressions.Regex.Replace(anoFaixa[0], "[^a-zA-Z0-9]", "");
            diario.IdProfessor = idProfessor;
            diario.IdComponente = idComponente;
            diario.IdTurma = idTurma;
            diario.Habilidade = _diarioDeClasseService.GetAllHabilidade(idComponente, anoFaixa[0]).ToList();

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
                        Data = Convert.ToDateTime(diarioDeClasse.Data)
                    };
                    string mensagem;
                    switch (_diarioDeClasseService.CreateDiarioClasse(diario, list))
                    {

                        case HttpStatusCode.OK:

                            mensagem = "<b>Sucesso:</b> Diário de Classe <b>Cadastrado</b>.";
                            Notificar(mensagem, Notifica.Sucesso);
                            continue;

                        case HttpStatusCode.InternalServerError:

                            mensagem = "<b>Erro:</b> Não foi possivel <b>Cadastrar</b> Diário de Classe";
                            Notificar(mensagem, Notifica.Erro);
                            return RedirectToAction(nameof(DiarioDeClasse), new { idTurma = diarioDeClasse.IdTurma, idComponente = diarioDeClasse.IdComponente });
                    }
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
            string mensagem;

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
                        switch (_frequenciaAlunoService.Create(freuqencia))
                        {

                            case HttpStatusCode.OK:

                                mensagem = "<b>Sucesso:</b> Frequência <b>Registrada</b>.";
                                Notificar(mensagem, Notifica.Sucesso);
                                continue;
                            case HttpStatusCode.InternalServerError:

                                mensagem = "<b>Erro:</b> Não foi possivel Registrar a Frequência";
                                Notificar(mensagem, Notifica.Erro);
                                return RedirectToAction(nameof(DiarioDeClasse), new { idTurma = frequenciaAluno.IdTurma, idComponente = frequenciaAluno.IdComponente });
                        }
                    }
                    else
                    {
                        switch (_frequenciaAlunoService.Edit(freuqencia))
                        {

                            case HttpStatusCode.OK:

                                mensagem = "<b>Sucesso:</b> Frequência <b>Registrada</b>.";
                                Notificar(mensagem, Notifica.Sucesso);
                                continue;
                            case HttpStatusCode.InternalServerError:

                                mensagem = "<b>Erro:</b> Não foi possivel Registrar a Frequência";
                                Notificar(mensagem, Notifica.Erro);
                                return RedirectToAction(nameof(DiarioDeClasse), new { idTurma = frequenciaAluno.IdTurma, idComponente = frequenciaAluno.IdComponente });
                        }
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
            string mensagem;
            ModelState.Remove("Habilidade");
            if (ModelState.IsValid)
            {
                Diariodeclasse diario = _mappers.Map<Diariodeclasse>(diarioDeClasse);

                switch (_diarioDeClasseService.Edit(diario))
                {

                    case HttpStatusCode.OK:

                        mensagem = "<b>Sucesso:</b> Diário de Classe <b>Editado</b>.";
                        Notificar(mensagem, Notifica.Sucesso);
                        return RedirectToAction(nameof(DiarioDeClasse), new { idTurma = diarioDeClasse.IdTurma, idComponente = diarioDeClasse.IdComponente });
                    case HttpStatusCode.InternalServerError:

                        mensagem = "<b>Erro:</b> Não foi possivel Editar o Diario de Classe";
                        Notificar(mensagem, Notifica.Erro);
                        return View(diarioDeClasse);
                }

            }
            try
            {
                return RedirectToAction(nameof(DiarioDeClasse), new { idTurma = diarioDeClasse.IdTurma, idComponente = diarioDeClasse.IdComponente });
            }
            catch
            {
                return View(diarioDeClasse);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDiarioClasse(DiarioDeClasseViewModel diarioDeClasse, int IdDiario, int IdObjeto)
        {

            diarioDeClasse = _mappers.Map<DiarioDeClasseViewModel>(_diarioDeClasseService.Get(IdDiario));
            string mensagem;
            switch (_diarioDeClasseService.DeleteDiarioClasse(IdDiario, IdObjeto))
            {

                case HttpStatusCode.OK:

                    mensagem = "<b>Sucesso:</b> Diário de Classe <b>Apagado</b>.";
                    Notificar(mensagem, Notifica.Sucesso);
                    return RedirectToAction(nameof(DiarioDeClasse), new { idTurma = diarioDeClasse.IdTurma, idComponente = diarioDeClasse.IdComponente });
                case HttpStatusCode.InternalServerError:

                    mensagem = "<b>Erro:</b> Não foi possivel Apagar o Diario de Classe";
                    Notificar(mensagem, Notifica.Erro);
                    return RedirectToAction(nameof(DiarioDeClasse), new { idTurma = diarioDeClasse.IdTurma, idComponente = diarioDeClasse.IdComponente });
            }


            return RedirectToAction(nameof(DiarioDeClasse), new { idTurma = diarioDeClasse.IdTurma, idComponente = diarioDeClasse.IdComponente });
        }


        public ActionResult ComunicacaoProfessorTurma(int idTurma, int idComponente)
        {
            ViewData["FlagLyoutProf"] = true;
            ComunicarProfessorTurmaViewModel model = new();

            model.Componente = _componenteService.Get(idComponente).Nome;
            model.Turma = _turmaService.Get(idTurma).Turma1;
            model.Alunos = _pessoaService.GetAlunosTurma(idTurma);
            model.IdComponente = idComponente;
            model.IdTurma = idTurma;
            return View(model);

        }

        [HttpPost]
        public ActionResult ComunicacaoProfessorTurma(ComunicarProfessorTurmaViewModel model)
        {
            if (ModelState.IsValid)
            {

                List<IndexAlunoTurmaDTO> alunos = new();

                foreach (var item in model.Alunos)
                {
                    if (item.Enviar == true)
                    {
                        alunos.Add(item);
                    }
                }

                Comunicacao comunicacao = new Comunicacao
                {
                    EnviarAlunos = 0,
                    EnviarResponsaveis = 0,
                    IdTurma = model.IdTurma,
                    Mensagem = model.Menssagem,
                    IdComponente = model.IdComponente,
                    IdPessoaRemetente = Convert.ToInt32(User.FindFirst("Id")?.Value),
                    Data = DateTime.Now


                };
                _comunicacaoService.SalvarComunicacao(comunicacao, alunos);
                Notificar("<b>Sucesso:</b> Comunicado <b>Enviado</b>.", Notifica.Sucesso);
            }

            return RedirectToAction(nameof(ComunicacaoProfessorTurma), new { idTurma = model.IdTurma, idComponente = model.IdComponente });
        }

    }
}
