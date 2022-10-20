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
    public class GovernoService : IGovernoService
    {
        private readonly ModernSchoolContext _context;

        public GovernoService (ModernSchoolContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Criar um novo governo
        /// </summary>
        /// <param name="governo"></param>
        /// <returns> Id do governo </returns>
        /// <exception cref="NotImplementedException"></exception>

        public int Create(Governo governo)
        {
            _context.Add(governo);
            _context.SaveChanges(); 
            return governo.Id;
        }

        /// <summary>
        /// Deletar governo do banco de dados 
        /// </summary>
        /// <param name="idGoverno"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(int idGoverno)
        {
            var _governo = _context.Governos.Find(idGoverno);
            _context.Remove(_governo);
            _context.SaveChanges();
        }

        public void Edit(Governo governo)
        {
           _context.Update(governo);
            _context.SaveChanges();
        }

        public Governo Get(int idGoverno)
        {
           return _context.Governos.Find(idGoverno);
        }

        public IEnumerable<Governo> GetAll()
        {
            return _context.Governos.AsNoTracking();
        }
    }
}
