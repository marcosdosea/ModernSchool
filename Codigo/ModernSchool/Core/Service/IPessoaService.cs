using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IPessoaService
    {
        int Create(Pessoa pessoa);
        void Edit(Pessoa pessoa);
        void Delete(int id);
        Pessoa Get(int id);
        IEnumerable<Pessoa> GetAll();
    }
}
