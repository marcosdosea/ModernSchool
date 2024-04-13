using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IComponenteService
    {
        HttpStatusCode Create(Componente componente);
        HttpStatusCode Edit(Componente componente);
        HttpStatusCode Delete(int id);
        Componente Get(int id);
        IEnumerable<Componente> GetAll();
    }
}
