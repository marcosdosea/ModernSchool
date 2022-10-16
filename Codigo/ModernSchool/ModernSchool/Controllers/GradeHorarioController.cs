using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ModernSchoolWEB.Models;
using Core;
namespace ModernSchool.Controllers
{

    public class GradeHorarioController : Controller
    {
        private readonly IGradeHorarioService _gradehorarioService;
        private readonly IMapper _mapper;

        public GradeHorarioController(IGradeHorarioService gradehorario, IMapper mapper)
        {
            _gradehorarioService = gradehorario;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var listaGradeHorario = _gradehorarioService.GetAll();
            var listaGradeHorarioModel = _mapper.Map<List<GradehorarioViewModel>>(listaGradeHorario);
            return View(listaGradeHorarioModel);
        }

        public ActionResult Details(int id)
        {
            Gradehorario listaGradehorario = _gradehorarioService.Get(id);
            GradehorarioViewModel gradehorarioModel = _mapper.Map<GradehorarioViewModel>(listaGradehorario);
            return View(gradehorarioModel);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GradehorarioViewModel gradehorarioModel)
        {
            if (ModelState.IsValid)
            {
                var gradeHorario = _mapper.Map<Gradehorario>(gradehorarioModel);
                _gradehorarioService.Create(gradeHorario);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            Gradehorario gradehorario = _gradehorarioService.Get(id);
            GradehorarioViewModel gradehorarioModel = _mapper.Map<GradehorarioViewModel>(gradehorario);
            return View(gradehorarioModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GradehorarioViewModel gradehorarioModel)
        {

            if (ModelState.IsValid)
            {
                Gradehorario gradehorario = _gradehorarioService.Get(id);
                _gradehorarioService.Edit(gradehorario);
            }

            return RedirectToAction(nameof(Index));

        }

        public ActionResult Delete(int id)
        {
            Gradehorario gradehorario = _gradehorarioService.Get(id);
            GradehorarioViewModel gradehorarioModel = _mapper.Map<GradehorarioViewModel>(gradehorario);
            return View(gradehorarioModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,GradehorarioViewModel gradehorarioModel )
        {
            _gradehorarioService.Delete(id);
            return RedirectToAction(nameof(Index)); 
        }
    }
}