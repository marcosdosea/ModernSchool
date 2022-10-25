using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;
using Service;

namespace ModernSchoolWEB.Controllers
{
    public class ObjetoDeConhecimentoController : Controller
    {
        private readonly IObjetoDeConhecimentoService _objetoDeConhecimentoService;
        private readonly IMapper _mapper;

        public ObjetoDeConhecimentoController(IObjetoDeConhecimentoService objetoDeConhecimentoService, IMapper mapper)
        {
            _objetoDeConhecimentoService = objetoDeConhecimentoService;
            _mapper = mapper;
        }

        // GET: ObjetoDeConhecimentoController
        public ActionResult Index()
        {
            var listaObjetoDeConhecimento = _objetoDeConhecimentoService.GetAll();
            var listaObjetoDeConhecimentoModel = _mapper.Map<List<ObjetoDeConhecimentoViewModel>>(listaObjetoDeConhecimento);
            return View(listaObjetoDeConhecimentoModel);
        }

        // GET: ObjetoDeConhecimentoController/Details/5
        public ActionResult Details(int id)
        {
            Objetodeconhecimento objetoDeConhecimento = _objetoDeConhecimentoService.Get(id);
            ObjetoDeConhecimentoViewModel objetoDeConhecimentoModel = _mapper.Map<ObjetoDeConhecimentoViewModel>(objetoDeConhecimento);
            return View(objetoDeConhecimentoModel);
        }

        // GET: ObjetoDeConhecimentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ObjetoDeConhecimentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ObjetoDeConhecimentoViewModel objetoDeConhecimentoViewModel)
        {
            if (ModelState.IsValid)
            {
                var objetoDeConhecimento = _mapper.Map<Objetodeconhecimento>(objetoDeConhecimentoViewModel);
                _objetoDeConhecimentoService.Create(objetoDeConhecimento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ObjetoDeConhecimentoController/Edit/5
        public ActionResult Edit(int id)
        {
            Objetodeconhecimento objetoDeConhecimento = _objetoDeConhecimentoService.Get(id);
            ObjetoDeConhecimentoViewModel objetoDeConhecimentoViewModel = _mapper.Map<ObjetoDeConhecimentoViewModel>(objetoDeConhecimento);
            return View(objetoDeConhecimentoViewModel);
        }

        // POST: ObjetoDeConhecimentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ObjetoDeConhecimentoViewModel objetoDeConhecimentoViewModel)
        {
            if (ModelState.IsValid)
            {
                var objetoDeConhecimento = _mapper.Map<Objetodeconhecimento>(objetoDeConhecimentoViewModel);
                _objetoDeConhecimentoService.Edit(objetoDeConhecimento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ObjetoDeConhecimentoController/Delete/5
        public ActionResult Delete(int id)
        {
            Objetodeconhecimento objetoDeConhecimento = _objetoDeConhecimentoService.Get(id);
            ObjetoDeConhecimentoViewModel objetoDeConhecimentoViewModel = _mapper.Map<ObjetoDeConhecimentoViewModel>(turma);
            return View(objetoDeConhecimentoViewModel);
        }

        // POST: ObjetoDeConhecimentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ObjetoDeConhecimentoViewModel objetoDeConhecimentoViewModel)
        {
            _objetoDeConhecimentoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
