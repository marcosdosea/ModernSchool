using AutoMapper;
using Core.Service;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Controllers
{
    public class ComunicacaoController : Controller
    {
        private readonly IComunicacaoService _comunicacaoService;
        private readonly IMapper _mapper;

        public ComunicacaoController(IComunicacaoService comunicacaoService, IMapper mapper)
        {
            _comunicacaoService = comunicacaoService;
            _mapper = mapper;
        }


        // GET: ComunicacaoController
        public ActionResult Index(int IdTurma)
        {
            ComunicacaoModel model = new();
            var listaComunicacao = _comunicacaoService.GetAll();
            model.Comunicacoes = listaComunicacao;
            model.IdTurma = IdTurma;
            return View(model);
        }

        // GET: ComunicacaoController/Details/5
        public ActionResult Details(int id)
        {
            Comunicacao comunicacao = _comunicacaoService.Get(id);
            ComunicacaoViewModel comunicacaoModel = _mapper.Map<ComunicacaoViewModel>(comunicacao);
            return View(comunicacaoModel);
        }

        // GET: ComunicacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComunicacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComunicacaoViewModel comunicacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var comunicacao = _mapper.Map<Comunicacao>(comunicacaoViewModel);
                _comunicacaoService.Create(comunicacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ComunicacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            Comunicacao comunicacao = _comunicacaoService.Get(id);
            ComunicacaoViewModel comunicacaoModel = _mapper.Map<ComunicacaoViewModel>(comunicacao);
            return View(comunicacaoModel);
        }

        // POST: ComunicacaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,ComunicacaoViewModel comunicacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var comunicacao = _mapper.Map<Comunicacao>(comunicacaoViewModel);
                _comunicacaoService.Edit(comunicacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ComunicacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            Comunicacao comunicacao = _comunicacaoService.Get(id);
            ComunicacaoViewModel comunicacaoViewModel = _mapper.Map<ComunicacaoViewModel>(comunicacao);
            return View(comunicacaoViewModel);
        }

        // POST: ComunicacaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ComunicacaoViewModel comunicacaoViewModel)
        {
            _comunicacaoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
