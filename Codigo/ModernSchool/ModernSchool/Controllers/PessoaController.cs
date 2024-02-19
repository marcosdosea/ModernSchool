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

namespace ModernSchoolWEB.Controllers
{

    //[Authorize(Roles = "PROFESSOR")]
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;
        private readonly ICargoService _cargoService;
        private readonly IMapper _mapper;
        private readonly IGovernoService _governoService;

        private readonly ISeedUserRoleInitial _userRole;
        public PessoaController(IPessoaService pessoaService, ICargoService cargoService,
            IMapper mapper, ISeedUserRoleInitial userRole, IGovernoService governoService)
        {
            _pessoaService = pessoaService;
            _cargoService = cargoService;
            _mapper = mapper;
            _userRole = userRole;
            _governoService = governoService;
        }



        // GET: PessoaController
        public ActionResult Index()
        {
            var listaPessoas = _pessoaService.GetAll();
            var listaPessoasModel = _mapper.Map<List<PessoaViewModel>>(listaPessoas);
            return View(listaPessoasModel);
        }


        // GET: PessoaController/Details/5
        public ActionResult Details(int id)
        {
            Pessoa pessoa = _pessoaService.Get(id);
            PessoaViewModel pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
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

            Pessoa pessoa = new Pessoa
            {
                Cpf = model.Cpf,
                Email = model.Email,
                Nome = model.Nome,
                DataNascimento = model.DataDeNascimento
            };

            if (_pessoaService.AdicionarCargo(pessoa, model.IdCargo, model.IdGoverno))
            {

                Cargo cargo = _cargoService.Get(model.IdCargo);

                await _userRole.SeedUsersAsync(pessoa, cargo.Descricao);

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));

        }
        // GET: PessoaController/Edit/5
        public ActionResult Edit(int id)
        {
            Pessoa pessoa = _pessoaService.Get(id);
            PessoaViewModel pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
            return View(pessoaModel);
        }

        // POST: PessoaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PessoaViewModel pessoaViewModel)
        {
            if (ModelState.IsValid)
            {
                var pessoa = _mapper.Map<Pessoa>(pessoaViewModel);
                _pessoaService.Edit(pessoa);
            }
            return RedirectToAction(nameof(Index));
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
        public ActionResult Delete(int id, PessoaViewModel pessoaViewModel)
        {
            _pessoaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }



        public ActionResult MatricularAluno()
        {
            return View();
        }


        [HttpPost]
        public ActionResult MatricularAluno(PessoaViewModel model)
        {

            if(_pessoaService?.GetById(model.Cpf) != null)
            {
                // metodo para add aluno turma 
            }




            return View(null);
        }



    }
}
