using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Service;
using AutoMapper;
using ModernSchoolWEB.Models;
using Core;

namespace ModernSchoolWEB.Controllers
{
    public class GovernoServidorController : Controller
    {

        private readonly IGovernoServidorService _governoService;
        private readonly IMapper _mapper;

        public GovernoServidorController(IGovernoServidorService governoService, IMapper mapper)
        {
            _governoService = governoService;
            _mapper = mapper;
        }



        // GET: GovernoServidorController
        public ActionResult Index()
        {
            var listaGovernoS = _governoService.GetAll();
            var listaGovernoM = _mapper.Map<List<GovernoServidorModel>>(listaGovernoS);

            return View(listaGovernoM);
        }

        // GET: GovernoServidorController/Details/5
        public ActionResult Details(int id)
        {
            Governoservidor governoServidor = _governoService.Get(id);
            var governoServidorM = _mapper.Map<GovernoServidorModel>(governoServidor);

            return View(governoServidorM);
        }

        // GET: GovernoServidorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GovernoServidorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GovernoServidorModel governoservidorM)
        {
            if (ModelState.IsValid)
            {
                var governoServidor = _mapper.Map<Governoservidor>(governoservidorM);
                _governoService.Create(governoServidor);
            }

            return RedirectToAction(nameof(Index));


        }

        // GET: GovernoServidorController/Edit/5
        public ActionResult Edit(int id)
        {
            Governoservidor governoservidor = _governoService.Get(id);
            GovernoServidorModel governoModel = _mapper.Map<GovernoServidorModel>(governoservidor);

            return View(governoModel);
        }

        // POST: GovernoServidorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GovernoServidorModel governoServidorModel)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<Governoservidor>(governoServidorModel);
                _governoService.Edit(model);
            }
            return RedirectToAction(nameof(Index));


        }

        // GET: GovernoServidorController/Delete/5
        public ActionResult Delete(int id)
        {
            Governoservidor governoS = _governoService.Get(id);
            GovernoServidorModel model = _mapper.Map<GovernoServidorModel>(governoS);

            return View(model);
        }

        // POST: GovernoServidorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, GovernoServidorModel governoServidorModel)
        {
            _governoService.Delete(id);

            return RedirectToAction(nameof(Index));


        }
    }
}
