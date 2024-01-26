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

    [Authorize(Roles = "PROFESSOR")]
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;
        private readonly ICargoService _cargoService;
        private readonly IMapper _mapper;
        private readonly UserManager<UsuarioIdentity> _userManager;
        private readonly IUserStore<UsuarioIdentity> _userStore;

        private readonly ISeedUserRoleInitial _userRole;
        public PessoaController(IPessoaService pessoaService, ICargoService cargoService,
            IMapper mapper, UserManager<UsuarioIdentity> userManager, IUserStore<UsuarioIdentity> userStore, ISeedUserRoleInitial userRole)
        {
            _pessoaService = pessoaService;
            _cargoService = cargoService;
            _mapper = mapper;
            _userManager = userManager;
            _userStore = userStore;
            _userRole = userRole;
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

            pessoaCargo.ListCargo = new SelectList(cargos, "IdCargo", "Descricao", null);

            return View(pessoaCargo);
        }
        [HttpPost]
        public async Task <ActionResult> AddPessoaCargo(AddPessoaCargoModel model)
        {

            Pessoa pessoa = new Pessoa
            {
                Email = model.Email
            };

            Cargo cargo = _cargoService.Get(model.IdCargo);


            await _userRole.SeedUsersAsync(pessoa, cargo.Descricao);

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
    }
}
