using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IGovernoService
    {
        int Crete(Governo governo);
        void Edit(Governo governo);
        void Delete(int idGoverno);
        Governo Get(int idGoverno);
        IEnumerable<Governo> GetAll();
    }
}
