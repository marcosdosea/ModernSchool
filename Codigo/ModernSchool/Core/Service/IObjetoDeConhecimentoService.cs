using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IObjetoDeConhecimentoService
    {
        int Create(Objetodeconhecimento objetoDeConhecimento);
        void Edit(Objetodeconhecimento objetoDeConhecimento);
        void Delete(int id);
        Objetodeconhecimento Get(int id);
        IEnumerable<Objetodeconhecimento> GetAll();

    }
}
