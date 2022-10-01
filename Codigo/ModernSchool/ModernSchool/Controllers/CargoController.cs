using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;
using Service;

namespace ModernSchoolWEB.Controllers
{
    public class CargoController : Controller
    {
        private readonly ICargoService _cargoService;
        private readonly IMapper _mapper;

        public CargoController(ICargoService cargoService, IMapper mapper)
        {
            _cargoService = cargoService;
            _mapper = mapper;
        }


        // GET: CargoController
        public ActionResult Index()
        {
            var listaCargo = _cargoService.GetAll();
            var listaCargoModel = _mapper.Map<List<CargoViewModel>>(listaCargo);
            return View(listaCargoModel);
        }

        // GET: CargoController/Details/5
        public ActionResult Details(int id)
        {
            Cargo cargo = _cargoService.Get(id);
            CargoViewModel cargoModel = _mapper.Map<CargoViewModel>(cargo);
            return View(cargoModel);
        }

        // GET: CargoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CargoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CargoViewModel cargoViewModel)
        {
            if (ModelState.IsValid)
            {
                var cargo = _mapper.Map<Cargo>(cargoViewModel);
                _cargoService.Create(cargo);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CargoController/Edit/5
        public ActionResult Edit(int id)
        {
            Cargo cargo = _cargoService.Get(id);
            CargoViewModel cargoModel = _mapper.Map<CargoViewModel>(cargo);
            return View(cargoModel);
        }

        // POST: CargoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CargoViewModel cargoViewModel)
        {
            if (ModelState.IsValid)
            {
                var cargo = _mapper.Map<Cargo>(cargoViewModel);
                _cargoService.Edit(cargo);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CargoController/Delete/5
        public ActionResult Delete(int id)
        {
            Cargo cargo = _cargoService.Get(id);
            CargoViewModel cargoViewModel = _mapper.Map<CargoViewModel>(cargo);
            return View(cargoViewModel);
        }

        // POST: CargoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CargoViewModel cargoViewModel)
        {
            _cargoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
