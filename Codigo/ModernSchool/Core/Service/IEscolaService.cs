using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IEscolaService
    {
        int Create(Escola escola);
        void Edit(Escola escola);
        void Delete(int escola);
        Escola Get(int escola);

        string GetNomeEscola(int idDiretor);
        IEnumerable<Escola> GetAll();
    }
}
