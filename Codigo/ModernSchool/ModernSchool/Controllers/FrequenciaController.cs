using AutoMapper;
using Core.Service;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Controllers
{
    public class FrequenciaController : Controller
    {
        private readonly IFrequenciaService _frequenciaService;
        private readonly IMapper _mapper;

        public FrequenciaController(IFrequenciaService frequenciaService, IMapper mapper)
        {
            _frequenciaService = frequenciaService;
            _mapper = mapper;
        }

        // GET: FrequenciaController
        public ActionResult Index()
        {
            var listaFrequecias = _frequenciaService.GetAll();
            var listaFrequenciaModel = _mapper.Map<List<FrequenciaViewModel>>(listaFrequecias);
            return View(listaFrequenciaModel);
        }

        // GET: FrequenciaController/Details/5
        public ActionResult Details(int id)
        {
            Frequenciaaluno frequencia = _frequenciaService.Get(id);
            FrequenciaViewModel frequenciaModel = _mapper.Map<FrequenciaViewModel>(frequencia);
            return View(frequenciaModel);
        }

        // GET: FrequenciaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FrequenciaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FrequenciaViewModel frequeciaModel)
        {
            if (ModelState.IsValid)
            {
                var frequencia = _mapper.Map<Frequenciaaluno>(frequeciaModel);
                _frequenciaService.Create(frequencia);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: FrequenciaController/Edit/5
        public ActionResult Edit(int id)
        {
            Frequenciaaluno frequencia = _frequenciaService.Get(id);
            FrequenciaViewModel frequenciaModel = _mapper.Map<FrequenciaViewModel>(frequencia);
            return View(frequenciaModel);
        }

        // POST: FrequenciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FrequenciaViewModel frequenciaViewModel)
        {
            if (ModelState.IsValid)
            {
                var frequencia = _mapper.Map<Frequenciaaluno>(frequenciaViewModel);
                _frequenciaService.Edit(frequencia);
            }
            return RedirectToAction(nameof(Index));
        }

        
    }
}
