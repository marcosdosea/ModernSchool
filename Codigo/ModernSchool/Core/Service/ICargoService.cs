using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ICargoService
    {
        int Create(Cargo cargo);
        void Edit(Cargo cargo);
        void Delete(int id);
        Cargo Get(int id);
        IEnumerable<Cargo> GetAll();
    }
}
