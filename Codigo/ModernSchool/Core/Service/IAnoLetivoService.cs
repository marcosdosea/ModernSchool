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
        Anoletivo Get(int anoletivo);
        IEnumerable<Anoletivo> GetAll();
    }
}
