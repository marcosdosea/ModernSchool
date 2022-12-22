using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModernSchoolWEB.Controllers
{
    public class AlunoAvaliacaoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAvaliacaoService _avaliacaoService;
        private readonly IAlunoAvaliacaoService _alunoAvaliacaoService;
        private readonly IPessoaService _pessoaService;
        // GET: AlunoAvaliacaoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AlunoAvaliacaoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AlunoAvaliacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlunoAvaliacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AlunoAvaliacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AlunoAvaliacaoController/Edit/5
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

        // GET: AlunoAvaliacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlunoAvaliacaoController/Delete/5
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
