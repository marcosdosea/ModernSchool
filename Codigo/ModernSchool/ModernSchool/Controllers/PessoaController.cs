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

namespace ModernSchoolWEB.Controllers
{

    [Authorize]
    public class PessoaController : Controller
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
            cpf = Regex.Replace(cpf, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
            cep = Regex.Replace(cep, @"(\d{5})(\d{3})", "$1-$2");
            pessoaModel.Cpf = cpf;
            pessoaModel.Cep = cep;
            pessoaModel.IdTurma = idTurma;
            return View(pessoaModel);
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
        public async Task <ActionResult> AddPessoaCargo(AddPessoaCargoModel model)
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
            if (ModelState.IsValid)
            {
                var pessoa = _mapper.Map<Pessoa>(pessoaViewModel);
                _pessoaService.Edit(pessoa);
            }
            return RedirectToAction("MatricularAlunoTurma", new {pessoaViewModel.IdTurma});
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
            Turma turma = _turmaService.Get(model.IdTurma);

            
            Pessoa aluno = _pessoaService.Get(model.Id);
            if(aluno == null)
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
                
                if(_pessoaService.MatricularNovoAlunoTurma(aluno, model.IdTurma))
                {
                    await _userRole.SeedUsersAsync(aluno, "Aluno");
                }
            }
            else
            {
                Alunoturma alunoTurma = new Alunoturma()
                {
                    IdAluno = aluno.Id,
                    IdTurma = model.IdTurma
                };

                _pessoaService.MatricularAlunoTurma(alunoTurma);
            }

            return RedirectToAction("MatricularAlunoTurma", new {idTurma = model.IdTurma});
        }
        [HttpPost]
        public IActionResult BuscarAlunoPorCPF(string cpf, int idTurma)
        {

            if(cpf == null)
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



    }
}
