using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IFrequenciaAlunoService
    {
        HttpStatusCode Create(Frequenciaaluno frequenciaaluno);
        HttpStatusCode Edit(Frequenciaaluno frequenciaaluno);
        void Delete(Frequenciaaluno frequenciaaluno);
        Frequenciaaluno Get(int idAluno, int idDiario);
        List<FrequenciaAlunoDTO> GetAllFrequenciaAlunoDTO(int idDiario);
        bool ExistFrequencia(int idDiario);

    }
}
