using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IFrequenciaalunoService
    {
        int Create(Frequenciaaluno frequencia);
        void Edit(Frequenciaaluno frequencia);

        Frequenciaaluno Get(int idPeriodo);
        IEnumerable<Frequenciaaluno> GetAll();
    }
}
