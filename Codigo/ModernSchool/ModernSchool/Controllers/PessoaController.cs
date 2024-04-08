using AutoMapper;
using Core.Service;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;
using Core.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using ModernSchoolWEB.Areas.Identity.Data;
using ModernSchoolWEB.Service;
using Microsoft.AspNetCore.Authorization;
using Service;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.RegularExpressions;
using static ModernSchoolWEB.Controllers.Notificacao;
using System.Net;
using Core.Datatables;

namespace ModernSchoolWEB.Controllers
{

    [Authorize]
    public class PessoaController : Notificacao
    {
        private readonly IPessoaService _pessoaService;
        private readonly ICargoService _cargoService;
        private readonly IMapper _mapper;
        private readonly IGovernoService _governoService;
        private readonly IGovernoServidorService _governoServidorService;
        private readonly ITurmaService _turmaService;
        private readonly IEscolaService _escolaService;

        private readonly ISeedUserRoleInitial _userRole;
        public PessoaController(IPessoaService pessoaService, ICargoService cargoService,
            IMapper mapper, ISeedUserRoleInitial userRole, IGovernoService governoService,
            IGovernoServidorService governoServidorService, ITurmaService turmaService,
            IEscolaService escolaService)
        {
            _pessoaService = pessoaService;
            _cargoService = cargoService;
            _mapper = mapper;
            _userRole = userRole;
            _governoService = governoService;
            _governoServidorService = governoServidorService;
            _turmaService = turmaService;
            _escolaService = escolaService;
        }



        // GET: PessoaController
        public ActionResult Index()
        {



            var listaPessoas = _pessoaService.GetAll();
            var listaPessoasModel = _mapper.Map<List<PessoaViewModel>>(listaPessoas);
            return View(listaPessoasModel);
        }


        // GET: PessoaController/Details/5
        public ActionResult Details(int id, int idTurma)
        {
            Pessoa pessoa = _pessoaService.Get(id);
            PessoaViewModel pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
            var cpf = pessoaModel.Cpf;
            var cep = pessoaModel.Cep;
            var telefone1 = pessoaModel.Telefone1;
            if (telefone1 != null)
            {
                telefone1 = Regex.Replace(telefone1, @"(\d{2})(\d{1})(\d{4})(\d{4})", "($1)-$2 $3-$4");
                pessoaModel.Telefone1 = telefone1;
            }
            var telefone2 = pessoaModel.Telefone2;
            if (telefone2 != null)
            {
                telefone2 = Regex.Replace(telefone2, @"(\d{2})(\d{1})(\d{4})(\d{4})", "($1)-$2 $3-$4");
                pessoaModel.Telefone2 = telefone2;
            }
            cpf = Regex.Replace(cpf, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
            cep = Regex.Replace(cep, @"(\d{5})(\d{3})", "$1-$2");
            pessoaModel.Cpf = cpf;
            pessoaModel.Cep = cep;

            pessoaModel.IdTurma = idTurma;
            return PartialView(pessoaModel);
        }

        // GET: PessoaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PessoaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaViewModel pessoaModel)
        {
            if (ModelState.IsValid)
            {
                var pessoa = _mapper.Map<Pessoa>(pessoaModel);
                _pessoaService.Create(pessoa);
            }
            return RedirectToAction(nameof(Index));

        }

        public ActionResult AddPessoaCargo()
        {
            AddPessoaCargoModel pessoaCargo = new AddPessoaCargoModel();
            IEnumerable<Cargo> cargos = _cargoService.GetAll();
            IEnumerable<Governo> governo = _governoService.GetAll();
            pessoaCargo.ListCargo = new SelectList(cargos, "IdCargo", "Descricao", null);
            pessoaCargo.ListaGoverno = new SelectList(governo, "Id", "Municipio", null);

            return View(pessoaCargo);
        }
        [HttpPost]
        public async Task<ActionResult> AddPessoaCargo(AddPessoaCargoModel model)
        {

            int idPessoa = _pessoaService.GetById(model.Cpf);
            Pessoa pessoa = _pessoaService.Get(idPessoa);
            if (pessoa == null)
            {
                pessoa = new Pessoa
                {
                    Cpf = model.Cpf,
                    Email = model.Email,
                    Nome = model.Nome,
                    DataNascimento = model.DataDeNascimento,
                    Cep = "4511899"
                };
            }


            if (_pessoaService.AdicionarCargo(pessoa, model.IdCargo, model.IdGoverno))
            {

                Cargo cargo = _cargoService.Get(model.IdCargo);

                await _userRole.SeedUsersAsync(pessoa, cargo.Descricao);

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));

        }
        // GET: PessoaController/Edit/5
        public ActionResult Edit(int id, int idTurma)
        {
            Pessoa pessoa = _pessoaService.Get(id);
            PessoaViewModel pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
            pessoaModel.IdTurma = idTurma;
            return View(pessoaModel);
        }

        // POST: PessoaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int idTurma, PessoaViewModel pessoaViewModel)
        {
            pessoaViewModel.IdTurma = idTurma;
            pessoaViewModel.Cep = pessoaViewModel.Cep.Replace("-", "");
            pessoaViewModel.Cpf = pessoaViewModel.Cpf.Replace("-", "").Replace(".", "");
            if (pessoaViewModel.Telefone1 != null)
            {
                pessoaViewModel.Telefone1 = pessoaViewModel.Telefone1.Replace("-", "").Replace("(", "").Replace(" ", "").Replace(")", "");
            }
            if (pessoaViewModel.Telefone2 != null)
            {
                pessoaViewModel.Telefone2 = pessoaViewModel.Telefone2.Replace("-", "").Replace("(", "").Replace(" ", "").Replace(")", "");
            }

            var pessoa = _mapper.Map<Pessoa>(pessoaViewModel);
            string mensagem = string.Empty;
            switch (_pessoaService.Edit(pessoa))
            {
                case HttpStatusCode.InternalServerError:
                    mensagem = "<b>Erro:</b> Não foi possével editar os dados  do Aluno(a).";
                    Notificar(mensagem, Notifica.Erro);
                    break;
                case HttpStatusCode.OK:
                    mensagem = "<b>Sucesso:</b> Os dados do Aluno(a) foram atualizados.";
                    Notificar(mensagem, Notifica.Sucesso);
                    break;

            }
            return RedirectToAction("MatricularAlunoTurma", new { pessoaViewModel.IdTurma });
        }

        // GET: PessoaController/Delete/5
        public ActionResult Delete(int id)
        {
            Pessoa pessoa = _pessoaService.Get(id);
            PessoaViewModel pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
            return View(pessoaModel);
        }

        // POST: PessoaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, int idTurma, PessoaViewModel pessoaViewModel)
        {
            pessoaViewModel.IdTurma = idTurma;
            _pessoaService.DeleteAlunoTurma(id, pessoaViewModel.IdTurma);
            string mensagem = "<b>Sucesso:</b> Aluno(a) <b>Removido</b> da turma.";
            Notificar(mensagem, Notifica.Sucesso);
            return RedirectToAction("MatricularAlunoTurma", new { pessoaViewModel.IdTurma });
        }



        public ActionResult MatricularAlunoTurma(int idTurma)
        {
            Turma turma = _turmaService.Get(idTurma);
            AlunoTurmaViewModel alunoModel = new AlunoTurmaViewModel();
            alunoModel.Alunos = _pessoaService.GetAlunosTurma(idTurma);
            alunoModel.Turma = turma.Turma1;
            alunoModel.Sala = turma.Sala;
            alunoModel.NumVagas = turma.VagasDisponiveis;
            alunoModel.IdTurma = idTurma;
            alunoModel.NomeEscola = _escolaService.GetNomeEscola(Convert.ToInt32(User.FindFirst("Id")?.Value));
            return View(alunoModel);
        }

        public ActionResult MatricularNovoAluno(int idTurma)
        {
            AlunoTurmaViewModel alunoModel = new AlunoTurmaViewModel();
            alunoModel.IdTurma = idTurma;
            return View(alunoModel);
        }
        [HttpPost]
        public async Task<ActionResult> MatricularNovoAluno(AlunoTurmaViewModel model)
        {
            model.Cpf = model.Cpf.Replace(".", "").Replace("-", "").Replace("_", "");
            model.Cep = model.Cep.Replace("-", "");
            if (model.Telefone1 != null)
            {
                model.Telefone1 = model.Telefone1.Replace("-", "").Replace("(", "").Replace(" ", "").Replace(")", "");
            }
            if (model.Telefone2 != null)
            {
                model.Telefone2 = model.Telefone2.Replace("-", "").Replace("(", "").Replace(" ", "").Replace(")", "");
            }
            Turma turma = _turmaService.Get(model.IdTurma);


            Pessoa aluno = _pessoaService.Get(model.Id);
            if (aluno == null)
            {
                aluno = new Pessoa()
                {
                    Nome = model.Nome,
                    Cpf = model.Cpf,
                    Bairro = model.Bairro,
                    Cep = model.Cep,
                    DataNascimento = model.DataNascimento,
                    Email = model.Email,
                    Numero = model.Numero,
                    Rua = model.Rua,
                    Uf = model.Uf,
                    Complemento = model.Complemento,
                    Telefone1 = model.Telefone1,
                    Telefone2 = model.Telefone2,
                    Cidade = model.Cidade

                };

                if (_pessoaService.MatricularNovoAlunoTurma(aluno, model.IdTurma))
                {
                    await _userRole.SeedUsersAsync(aluno, "Aluno");
                    string mensagem = "<b>Sucesso:</b> Aluno(a) foi <b>Matriculado</b> na turma";
                    Notificar(mensagem, Notifica.Sucesso);
                }
            }
            else
            {
                if (_pessoaService.AlunoMatriculado(aluno.Id))
                {
                    string mensagem = "<b>Alerta</b>: Aluno(a) já está <b>Matriculado</b> em uma Turma.";
                    Notificar(mensagem, Notifica.Alerta);
                }
                else
                {
                    Alunoturma alunoTurma = new Alunoturma()
                    {
                        IdAluno = aluno.Id,
                        IdTurma = model.IdTurma
                    };

                    _pessoaService.MatricularAlunoTurma(alunoTurma);
                    string mensagem = "<b>Sucesso:</b> Aluno(a) foi <b>Matriculado</b> na turma";
                    Notificar(mensagem, Notifica.Sucesso);
                }
            }

            return RedirectToAction("MatricularAlunoTurma", new { idTurma = model.IdTurma });
        }
        [HttpPost]
        public IActionResult BuscarAlunoPorCPF(string cpf, int idTurma)
        {

            if (cpf == null)
            {
                cpf = "";
            }
            cpf = cpf.Replace(".", "").Replace("-", "").Replace("_", "");
            int idEscola = _turmaService.GetByIdEscola(idTurma);
            Pessoa pessoa = _pessoaService.GetAluno(idEscola, cpf);
            if (pessoa != null)
            {
                return Json(pessoa);
            }
            else
            {
                //pessoa.Cep = pessoa.Cep.Replace("-", "");
                return Json(pessoa);
            }
        }
        [HttpPost]
        [Route("/Pessoa/GetDataPage/{idTurma}")]
        public IActionResult GetDataPage(DatatableRequest request, int idTurma)
        {
            
            var response = _pessoaService.GetDataPage(request, idTurma);
            return Json(response);
        }



    }
}
