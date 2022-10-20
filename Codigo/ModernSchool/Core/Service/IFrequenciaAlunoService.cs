using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IFrequenciaAlunoService
    {
        int Create(Frequenciaaluno frequenciaAluno);
        void Edit(Frequenciaaluno frequenciaAluno);
       
        Frequenciaaluno Get(int idFrequenciaAluno);
        IEnumerable<Frequenciaaluno> GetAll();
    }
}
