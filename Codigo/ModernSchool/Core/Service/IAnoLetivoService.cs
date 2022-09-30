using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAnoLetivoService
    {
        int Create(Anoletivo anoletivo);
        void Edit(Anoletivo anoletivo);
        void Delete(int anoletivo);
        Periodo Get(int anoletivo);
        IEnumerable<Periodo> GetAll();
    }
}
