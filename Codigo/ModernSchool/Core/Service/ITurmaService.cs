using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ITurmaService
    {
        HttpStatusCode Create(Turma turma);
        HttpStatusCode Edit(Turma turma);
        HttpStatusCode Delete(int id);
        Turma Get(int id);
        IEnumerable<Turma> GetAll();

        int GetByIdEscola(int idTurma);
        IEnumerable<EscolaProfessorDTO> EscolaVinculadaProfessor();
    }
}
