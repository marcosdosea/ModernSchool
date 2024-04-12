using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModernSchoolWEB.Models;
using System.Linq.Expressions;
using System.Net;
using static ModernSchoolWEB.Controllers.Notificacao;

namespace ModernSchoolWEB.Controllers
{
    public class PeriodoController : Notificacao
    {
        private readonly IPeriodoService _periodoService;
        private readonly IMapper _mapper;
        private readonly IAnoLetivoService _anoLetivoService;

        public PeriodoController(IPeriodoService periodoService, IAnoLetivoService anoLetivoService, IMapper mapper)
        {
            _periodoService = periodoService;
            _mapper = mapper;
            _anoLetivoService = anoLetivoService;
        }

        // GET: PeriodoController
        public ActionResult Index()
        {
            var listaPeriodos = _periodoService.GetAll();
            var listaPeriodosModel = _mapper.Map<List<PeriodoViewModel>>(listaPeriodos);
            return View(listaPeriodosModel);
        }

        // GET: PeriodoController/Details/5
        public ActionResult Details(int id)
        {
            Periodo periodo = _periodoService.Get(id);
            PeriodoViewModel periodoModel = _mapper.Map<PeriodoViewModel>(periodo);
            return View(periodoModel);
        }

        // GET: PeriodoController/Create
        public ActionResult Create()
        {
            PeriodoViewModel periodoViewModel = new();
            periodoViewModel.listaAnoLetivo = new SelectList(_anoLetivoService.GetAll(), "AnoLetivo", "AnoLetivo", null);
            return View(periodoViewModel);
        }

        // POST: PeriodoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PeriodoViewModel periodoModel)
        {
            string mensagem;
            ModelState.Remove("listaAnoLetivo");
            if (ModelState.IsValid)
            {
                var periodo = _mapper.Map<Periodo>(periodoModel);
                switch (_periodoService.Create(periodo))
                {
                    case HttpStatusCode.BadRequest:

                        mensagem = "<b>Erro:</b> Já existe Período <b>Cadastrada</b> com esse nome.";
                        Notificar(mensagem, Notifica.Alerta);
                        return RedirectToAction(nameof(Create), periodoModel);

                    case HttpStatusCode.OK:


                        mensagem = "<b>Sucesso:</b> Período <b>Cadastrada</b>.";
                        Notificar(mensagem, Notifica.Sucesso);
                        return RedirectToAction(nameof(Index));

                    case HttpStatusCode.InternalServerError:

                        mensagem = "<b>Erro:</b> Erro ao <b>Cadastrada</b> Período.";
                        Notificar(mensagem, Notifica.Erro);
                        return RedirectToAction(nameof(Create), periodoModel);
                }
            }
            return RedirectToAction(nameof(Create), periodoModel);
        }

        // GET: PeriodoController/Edit/5
        public ActionResult Edit(int id)
        {
            Periodo periodo = _periodoService.Get(id);
            PeriodoViewModel periodoModel = _mapper.Map<PeriodoViewModel>(periodo);
            periodoModel.listaAnoLetivo = new SelectList(_anoLetivoService.GetAll(), "AnoLetivo", "AnoLetivo", null);
            return View(periodoModel);
        }

        // POST: PeriodoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PeriodoViewModel periodoViewModel)
        {
            string mensagem;
            ModelState.Remove("listaAnoletivo");
            if (ModelState.IsValid)
            {
                var periodo = _mapper.Map<Periodo>(periodoViewModel);
                
                switch (_periodoService.Edit(periodo))
                {
                    case HttpStatusCode.BadRequest:

                        mensagem = "<b>Erro:</b> Já existe Período <b>Cadastrada</b> com esse nome.";
                        Notificar(mensagem, Notifica.Alerta);
                        return RedirectToAction(nameof(Edit), periodoViewModel.Id);

                    case HttpStatusCode.OK:

                        mensagem = "<b>Sucesso:</b> Período <b>Editado</b>.";
                        Notificar(mensagem, Notifica.Sucesso);
                        return RedirectToAction(nameof(Index));

                    case HttpStatusCode.InternalServerError:

                        mensagem = "<b>Erro:</b> Erro ao <b>Editar</b> Período.";
                        Notificar(mensagem, Notifica.Erro);
                        return RedirectToAction(nameof(Edit), periodoViewModel.Id);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PeriodoController/Delete/5
        public ActionResult Delete(int id)
        {
            Periodo periodo = _periodoService.Get(id);
            PeriodoViewModel periodoModel = _mapper.Map<PeriodoViewModel>(periodo);
            return View(periodoModel);
        }

        // POST: PeriodoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PeriodoViewModel periodoViewModel)
        {
            string mensagem;
            switch (_periodoService.Delete(id))
            {
                case HttpStatusCode.OK:


                    mensagem = "<b>Sucesso:</b> Período <b>Apagado</b>.";
                    Notificar(mensagem, Notifica.Sucesso);
                    return RedirectToAction(nameof(Index));

                case HttpStatusCode.InternalServerError:

                    mensagem = "<b>Erro:</b> Erro ao <b>Apagar</b> Período.";
                    Notificar(mensagem, Notifica.Erro);
                    return RedirectToAction(nameof(Create), periodoViewModel);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
