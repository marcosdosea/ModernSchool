using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IComponenteService
    {
        int Create(Componente componente);
        void Edit(Componente componente);
        void Delete(int id);
        Componente Get(int id);
        IEnumerable<Componente> GetAll();
    }
}
