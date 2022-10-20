using AutoMapper;
using Core.Service;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Controllers
{
    public class FrequenciaAlunoController : Controller
    {
        private readonly IFrequenciaAlunoService _frequenciaService;
        private readonly IMapper _mapper;

        public FrequenciaAlunoController(IFrequenciaAlunoService frequenciaService, IMapper mapper)
        {
            _frequenciaService = frequenciaService;
            _mapper = mapper;
        }

        // GET: FrequenciaController
        public ActionResult Index()
        {
            var listaFrequecias = _frequenciaService.GetAll();
            var listaFrequenciaModel = _mapper.Map<List<FrequenciaAlunoViewModel>>(listaFrequecias);
            return View(listaFrequenciaModel);
        }

        // GET: FrequenciaController/Details/5
        public ActionResult Details(int id)
        {
            Frequenciaaluno frequencia = _frequenciaService.Get(id);
            FrequenciaAlunoViewModel frequenciaModel = _mapper.Map<FrequenciaAlunoViewModel>(frequencia);
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
        public ActionResult Create(FrequenciaAlunoViewModel frequeciaModel)
        {
            if (ModelState.IsValid)
            {
                var frequencia = _mapper.Map<Frequenciaaluno>(frequeciaModel);
                _frequenciaService.Create(frequencia);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: FrequenciaController/Edit/5
        public ActionResult Edit(int idPessoa)
        {
            Frequenciaaluno frequencia = _frequenciaService.Get(idPessoa);
            FrequenciaAlunoViewModel frequenciaModel = _mapper.Map<FrequenciaAlunoViewModel>(frequencia);
            return View(frequenciaModel);
        }

        // POST: FrequenciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FrequenciaAlunoViewModel frequenciaViewModel)
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
