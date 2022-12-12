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
    public class DiarioDeClasseService : IDiarioDeClasseService
    {
         private readonly ModernSchoolContext _context;

        public DiarioDeClasseService(ModernSchoolContext context)
        {
            _context = context;
        }

        public int Create(Diariodeclasse diariodeclasse)
        {
            throw new NotImplementedException();
        }

        public void Delete(int diariodeclasse)
        {
            throw new NotImplementedException();
        }

        public void Edit(Diariodeclasse diariodeclasse)
        {
            throw new NotImplementedException();
        }

        public Anoletivo Get(int diariodeclasse)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diariodeclasse> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
