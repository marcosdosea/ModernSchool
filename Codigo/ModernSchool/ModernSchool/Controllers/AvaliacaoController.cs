using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchool.Models;

namespace ModernSchool.Controllers
{
    public class AvaliacaoController : Controller
    {

        private readonly IAvaliacaoService _avaliacaoService;
        private readonly IMapper _mapper;

        public AvaliacaoController(IAvaliacaoService avaliacaoService, IMapper mapper)
        {
            _avaliacaoService = avaliacaoService;
            _mapper = mapper;
        }

        // GET: AvaliacaoController1
        public ActionResult Index()
        {
            var listaAvaliacao = _avaliacaoService.GetAll();
            var listaAvaliacaoModel = _mapper.Map<List<AvaliacaoViewModel>>(listaAvaliacao);

            return View(listaAvaliacaoModel);
        }

        // GET: AvaliacaoController1/Details/5
        public ActionResult Details(int id)
        {
            Avaliacao avaliacao = _avaliacaoService.Get(id);
            AvaliacaoViewModel avaliacaoModel = _mapper.Map<AvaliacaoViewModel>(avaliacao);

            return View(avaliacaoModel);
        }

        // GET: AvaliacaoController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvaliacaoController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AvaliacaoViewModel avaliacaoModel)
        {
            try
            {
                var avaliacao = _mapper.Map<Avaliacao>(avaliacaoModel);
                _avaliacaoService.Create(avaliacao);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AvaliacaoController1/Edit/5
        public ActionResult Edit(int id)
        {
            Avaliacao avaliacao = _avaliacaoService.Get(id);
            AvaliacaoViewModel avaliacaoModel = _mapper.Map<AvaliacaoViewModel>(avaliacao);

            return View(avaliacaoModel);
        }

        // POST: AvaliacaoController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AvaliacaoViewModel avaliacaoModel)
        {
            try
            {
                var avaliacao = _mapper.Map<Avaliacao>(avaliacaoModel);
                _avaliacaoService.Edit(avaliacao);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AvaliacaoController1/Delete/5
        public ActionResult Delete(int id)
        {
            Avaliacao avaliacao = _avaliacaoService.Get(id);
            AvaliacaoViewModel avaliacaoModel = _mapper.Map<AvaliacaoViewModel>(avaliacao);

            return View(avaliacaoModel);
        }

        // POST: AvaliacaoController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AvaliacaoViewModel avaliacaoModel)
        {
            try
            {
                _avaliacaoService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
