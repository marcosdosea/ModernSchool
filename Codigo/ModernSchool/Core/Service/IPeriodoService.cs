using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IPeriodoService
    {
        int Create(Periodo periodo);
        void Edit(Periodo periodo);
        void Delete(int idPeriodo);
        Periodo Get(int idPeriodo);
        IEnumerable<Periodo> GetAll();
    }
}
