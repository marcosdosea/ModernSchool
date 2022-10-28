using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class GovernoServidorService : IGovernoServidorService
    {
        private readonly ModernSchoolContext _context;

        public GovernoServidorService(ModernSchoolContext context)
        {
            _context = context;
        }   

        public int Create(Governoservidor governoservidor)
        {
            _context.Add(governoservidor);
            _context.SaveChanges();
            return governoservidor.IdGoverno;
        }

        public void Delete(int id)
        {
            var governoservidor = _context.Governoservidors.Find(id);
            _context.Remove(governoservidor);
            _context.SaveChanges();
        }

        public void Edit(Governoservidor governoservidor)
        {
            _context.Update(governoservidor);
            _context.SaveChanges();
        }

        public Governoservidor Get(int id)
        {
            return _context.Governoservidors.Find(id);
        }

        public IEnumerable<Governoservidor> GetAll()
        {
            return _context.Governoservidors.AsNoTracking();

        }
    }
}
