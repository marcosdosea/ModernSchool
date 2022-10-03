using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ITurmaService
    {
        int Create(Turma turma);
        void Edit(Turma turma);
        void Delete(int turma);
        Turma Get(int turma);
        IEnumerable<Turma> GetAll();
    }
}
