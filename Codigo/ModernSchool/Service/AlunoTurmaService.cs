using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AlunoTurmaService : IAlunoTurma
    {
        private readonly ModernSchoolContext _context;

        public AlunoTurmaService (ModernSchoolContext context)
        {
            _context = context;
        }
        public int Matricular(Alunoturma alunoTurma)
        {
            _context.Add(alunoTurma);
            _context.SaveChanges();
            return alunoTurma.IdTurma;
        }
    }
}
