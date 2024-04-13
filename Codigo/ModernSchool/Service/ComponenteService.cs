using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Service
{
    public class ComponenteService : IComponenteService
    {
        private readonly ModernSchoolContext _context;

        public ComponenteService(ModernSchoolContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Criar um componente no banco de dados
        /// </summary>
        /// <param name="componente">Dados do periodo</param>
        /// <returns>Id do componente</returns>
        HttpStatusCode IComponenteService.Create(Componente componente)
        {
            var existingComponente = _context.Componentes.FirstOrDefault(c => c.Nome.ToLower() == componente.Nome.ToLower());
            if (existingComponente != null)
            {
                return HttpStatusCode.BadRequest;
            }
            try
            {
                _context.Add(componente);
                _context.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        /// <summary>
        /// Deletar um componente no banco de dados
        /// </summary>
        /// <param name="id"></param>
        HttpStatusCode IComponenteService.Delete(int id)
        {
            try
            {
                var _componente = _context.Componentes.Find(id);
                _context.Remove(_componente);
                _context.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        /// <summary>
        /// Editar um componente no banco de dados
        /// </summary>
        /// <param name="componente">Dados do periodo</param>
        HttpStatusCode IComponenteService.Edit(Componente componente)
        {
            var existingComponente = _context.Componentes.FirstOrDefault(c => c.Nome.ToLower() == componente.Nome.ToLower());
            if (existingComponente != null)
            {
                return HttpStatusCode.BadRequest;
            }
            try
            {
                _context.Update(componente);
                _context.SaveChanges();
                return HttpStatusCode.OK;
            }catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        /// <summary>
        /// Consultar um componente no banco
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Dados do componente</returns>
        Componente IComponenteService.Get(int id)
        {
            return _context.Componentes.Find(id);
        }

        /// <summary>
        /// Consultar todos os componentes no banco
        /// </summary>
        /// <returns></returns>
        IEnumerable<Componente> IComponenteService.GetAll()
        {
            return _context.Componentes.AsNoTracking().OrderBy(g => g.Nome);
        }
    }
}
