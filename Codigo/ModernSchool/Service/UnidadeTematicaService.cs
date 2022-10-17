using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UnidadeTematicaService : IUnidadeTematicaService
    {
        private readonly ModernSchoolContext _context;

        public UnidadeTematicaService(ModernSchoolContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Criar uma unidade tematica no banco de dados
        /// </summary>
        /// <param name="unidadetematica"></param>
        /// <returns></returns>
        int IUnidadeTematicaService.Create(Unidadetematica unidadetematica)
        {
            _context.Add(unidadetematica);
            _context.SaveChanges();
            return unidadetematica.Id;
        }

        /// <summary>
        /// Deletar uma unidade tematica no banco de dados
        /// </summary>
        /// <param name="id"></param>
        void IUnidadeTematicaService.Delete(int id)
        {
            var _unidadetematica = _context.Unidadetematicas.Find(id);
            _context.Remove(_unidadetematica);
            _context.SaveChanges();
        }

        /// <summary>
        /// Editar uma unidade tematica no banco de dados
        /// </summary>
        /// <param name="unidadetematica"></param>
        void IUnidadeTematicaService.Edit(Unidadetematica unidadetematica)
        {
            _context.Update(unidadetematica);
            _context.SaveChanges();
        }

        /// <summary>
        /// Consultar uma unidade tematica no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Turma IUnidadeTematicaService.Get(int id)
        {
            return _context.Turmas.Find(id);
        }

        /// <summary>
        /// Consultar todas as unidades tematicas no banco de dados
        /// </summary>
        /// <returns>Dados de todas as unidades tematicas</returns>
        IEnumerable<Unidadetematica> IUnidadeTematicaService.GetAll()
        {
            return _context.Unidadetematicas.AsNoTracking();
        }
    }
}
