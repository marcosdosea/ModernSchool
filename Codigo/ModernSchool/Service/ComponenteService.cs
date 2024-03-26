using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        int IComponenteService.Create(Componente componente)
        {
            _context.Add(componente);
            _context.SaveChanges();
            return componente.Id;
        }

        /// <summary>
        /// Deletar um componente no banco de dados
        /// </summary>
        /// <param name="id"></param>
        void IComponenteService.Delete(int id)
        {
            var _componente = _context.Componentes.Find(id);
            _context.Remove(_componente);
            _context.SaveChanges();
        }

        /// <summary>
        /// Editar um componente no banco de dados
        /// </summary>
        /// <param name="componente">Dados do periodo</param>
        void IComponenteService.Edit(Componente componente)
        {
            _context.Update(componente);
            _context.SaveChanges();
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
