using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolWEB.Models;
using Service;
using static ModernSchoolWEB.Controllers.Notificacao;
using System.Net;

namespace ModernSchoolWEB.Controllers
{
    public class ComponenteController : Notificacao
    {
        private readonly IComponenteService _componenteService;
        private readonly IMapper _mapper;
        public ComponenteController(IComponenteService componenteService, IMapper mapper)
        {
            _componenteService = componenteService;
            _mapper = mapper;
        }


        // GET: ComponenteController
        public ActionResult Index()
        {
            var listaComponente = _componenteService.GetAll();
            var listaComponenteModel = _mapper.Map<List<ComponenteViewModel>>(listaComponente);
            return View(listaComponenteModel);
        }

        // GET: ComponenteController/Details/5
        public ActionResult Details(int id)
        {
            Componente componente = _componenteService.Get(id);
            ComponenteViewModel componenteModel = _mapper.Map<ComponenteViewModel>(componente);
            return View(componenteModel);
        }

        // GET: ComponenteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComponenteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComponenteViewModel componenteViewModel)
        {
            string mensagem;
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                var componente = _mapper.Map<Componente>(componenteViewModel);
                switch (_componenteService.Create(componente))
                {
                    case HttpStatusCode.BadRequest:

                        mensagem = "<b>Erro:</b> Já existe Componente <b>Cadastrada</b> com esse nome.";
                        Notificar(mensagem, Notifica.Alerta);
                        return RedirectToAction(nameof(Create), componenteViewModel.id);

                    case HttpStatusCode.OK:

                        mensagem = "<b>Sucesso:</b> Componente <b>Cadastrado</b>.";
                        Notificar(mensagem, Notifica.Sucesso);
                        return RedirectToAction(nameof(Index));

                    case HttpStatusCode.InternalServerError:

                        mensagem = "<b>Erro:</b> Erro ao <b>Cadastrar</b> Componente.";
                        Notificar(mensagem, Notifica.Erro);
                        return RedirectToAction(nameof(Create), componenteViewModel.id);
                }
                
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ComponenteController/Edit/5
        public ActionResult Edit(int id)
        {
            Componente componente = _componenteService.Get(id);
            ComponenteViewModel componenteModel = _mapper.Map<ComponenteViewModel>(componente);
            return View(componenteModel);
        }

        // POST: ComponenteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ComponenteViewModel componenteViewModel)
        {
            string mensagem;
            if (ModelState.IsValid)
            {
                var componente = _mapper.Map<Componente>(componenteViewModel);
                switch (_componenteService.Edit(componente))
                {
                    case HttpStatusCode.BadRequest:

                        mensagem = "<b>Erro:</b> Já existe Componente <b>Cadastrada</b> com esse nome.";
                        Notificar(mensagem, Notifica.Alerta);
                        return RedirectToAction(nameof(Edit), componenteViewModel.id);

                    case HttpStatusCode.OK:

                        mensagem = "<b>Sucesso:</b> Componente <b>Editado</b>.";
                        Notificar(mensagem, Notifica.Sucesso);
                        return RedirectToAction(nameof(Index));

                    case HttpStatusCode.InternalServerError:

                        mensagem = "<b>Erro:</b> Erro ao <b>Editar</b> Componente.";
                        Notificar(mensagem, Notifica.Erro);
                        return RedirectToAction(nameof(Edit), componenteViewModel.id);
                }

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ComponenteController/Delete/5
        public ActionResult Delete(int id)
        {
            Componente componente = _componenteService.Get(id);
            ComponenteViewModel componenteViewModel = _mapper.Map<ComponenteViewModel>(componente);
            return View(componenteViewModel);
        }

        // POST: ComponenteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ComponenteViewModel componenteViewModel)
        {
            string mensagem;
            switch (_componenteService.Delete(id))
            {

                case HttpStatusCode.OK:

                    mensagem = "<b>Sucesso:</b> Componente <b>Apagado</b>.";
                    Notificar(mensagem, Notifica.Sucesso);
                    return RedirectToAction(nameof(Index));

                case HttpStatusCode.InternalServerError:

                    mensagem = "<b>Erro:</b> Componente já está em uso";
                    Notificar(mensagem, Notifica.Erro);
                    return RedirectToAction(nameof(Index));
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
