using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IFrequenciaAlunoService
    {
        int Create(Frequenciaaluno frequenciaaluno);
        int Edit(Frequenciaaluno frequenciaaluno);
        void Delete(Frequenciaaluno frequenciaaluno);
        Frequenciaaluno Get(int Frequenciaaluno);
        IEnumerable<FrequenciaAlunoDTO> GetAllFrequenciaAlunoDTO();

    }
}
