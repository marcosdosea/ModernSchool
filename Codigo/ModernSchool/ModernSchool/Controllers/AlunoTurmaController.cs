using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Controllers
{
    public class AlunoTurmaController : Controller
    {


        private readonly IAlunoTurma _alunoTurma;
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public AlunoTurmaController(IAlunoTurma alunoTurma, IPessoaService pessoaService, IMapper mapper)
        {
            _alunoTurma = alunoTurma;
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        // GET: AlunoTurmaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AlunoTurmaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AlunoTurmaController/Create
        public ActionResult AdicionarAluno( int idTurma)
        {
            AlunoTurmaViewModel model = new AlunoTurmaViewModel();
            model.IdTurma = idTurma;

            IEnumerable<Pessoa> listaPessoa = _pessoaService.GetAll();

            model.listaAluno = new SelectList(listaPessoa, "idAluno", "Name", null);

            return View(model);
        }

        // POST: AlunoTurmaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarAluno(AlunoTurmaViewModel model)
        {
            Alunoturma alunoTurma = new Alunoturma();
            alunoTurma.IdTurma = model.IdTurma;
            alunoTurma.IdAluno = model.IdAluno;

            _alunoTurma.Matricular(alunoTurma);

            return View();
        }

        // GET: AlunoTurmaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AlunoTurmaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlunoTurmaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlunoTurmaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
