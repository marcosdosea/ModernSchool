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
    public class AnoLetivoService : IAnoLetivoService
    {
        private readonly ModernSchoolContext _context;

        public AnoLetivoService(ModernSchoolContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Criar um ano letivo no banco de dados
        /// </summary>
        /// <param name="anoLetivo">Dados do ano letivo</param>
        /// <returns>Id do ano letivo</returns>
        public int Create(Anoletivo anoLetivo)
        {
            _context.Add(anoLetivo);
            _context.SaveChanges();
            return anoLetivo.AnoLetivo;
        }
        /// <summary>
        /// Deletar um ano letivo no banco de dados
        /// </summary>
        /// <param name="Anoletivo">Id do ano letivo</param>
        public void Delete(int anoletivo)
        {
            var _anoLetivo = _context.Anoletivos.Find(anoletivo);
            _context.Remove(_anoLetivo);
            _context.SaveChanges();
        }
        /// <summary>
        /// Editar um ano letivo no banco de dados
        /// </summary>
        /// <param name="Anoletivo">Dados do ano letivo</param>
        public void Edit(Anoletivo anoletivo)
        {
            _context.Update(anoletivo);
            _context.SaveChanges();
        }
        /// <summary>
        /// Consultar um ano letivo no banco
        /// </summary>
        /// <param name="Anoletivo"></param>
        /// <returns>Dados do ano letivo</returns>
        public Anoletivo Get(int anoletivo)
        {
            return _context.Anoletivos.Find(anoletivo);
        }
        /// <summary>
        /// Consultar todos os anos letivos no banco
        /// </summary>
        /// <returns>Dados de todos os anos letivos</returns>
        public IEnumerable<Anoletivo> GetAll()
        {
            return _context.Anoletivos.AsNoTracking();
        }
    }
}
