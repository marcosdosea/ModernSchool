using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ITurmaService
    {
            int Create(Turma turma);
            void Edit(Turma turma);
            void Delete(int id);
            Turma Get(int id);
            IEnumerable<Turma> GetAll();
            IEnumerable<EscolaProfessorDTO> EscolaVinculadaProfessor();
    }
}
